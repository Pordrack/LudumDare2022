using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AleaSpawner : MonoBehaviour
{
    //Le temps moyen entre l'apparition de chaque alea
    public float SpawnTime = 40;
    //La variation que subit aleatoirement chaque temps (en pourcentage du temps actuel)
    public float SpawnTimeSpread = 0.5f;
    //Le rate auquel la durée baisse
    public float SpawnAcceleration = 0.001f;

    //La variation que subit aleatoirement chaque durée d'event (en pourcentage)
    public float EventTimeSpread = 0.5f;

    private float spawnTimer;

    public AleaTemplate[] Aleas;

    private AleaTemplate AleaToBeSpawned=null;

    public TMP_Text TitleTMP;
    public TMP_Text DescriptionTMP;
    public TMP_Text WarningTMP;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = SpawnTime + Random.Range(-SpawnTimeSpread * SpawnTime, SpawnTimeSpread * SpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        SpawnTime -= Time.deltaTime * SpawnAcceleration;

        //Peut avant le début de l'event on le "prépare" et l'affiche
        if(spawnTimer<5 && AleaToBeSpawned == null)
        {
            AleaToBeSpawned = Aleas[Random.Range(0, Aleas.Length)];
            TitleTMP.enabled = true;
            TitleTMP.text = AleaToBeSpawned.AleaName;
            DescriptionTMP.enabled = true;
            DescriptionTMP.text = AleaToBeSpawned.AleaDescription;
            WarningTMP.enabled = true;
        }

        if (spawnTimer > 0)
            return;

        Spawn();
    }

    void Spawn()
    {
        //On enleve les ecritaux prevenant de sa venue et on spawn l'event
        TitleTMP.enabled = false;
        DescriptionTMP.enabled = false;
        WarningTMP.enabled = false;
        AleaToBeSpawned.script.OnTrigger();
        //OPuis on definie sa durée et prépare sa fin
        float duration = AleaToBeSpawned.BaseMediumTime + 
            Random.Range(-EventTimeSpread * AleaToBeSpawned.BaseMediumTime, 
            EventTimeSpread * AleaToBeSpawned.BaseMediumTime);
        StartCoroutine(stopAlea(AleaToBeSpawned.script, duration));

        //On reset les variables pour le prochain event
        spawnTimer= SpawnTime + Random.Range(-SpawnTimeSpread * SpawnTime, SpawnTimeSpread * SpawnTime);
        AleaToBeSpawned = null;
    }

    IEnumerator stopAlea(AleaScript aleaToStop, float time)
    {
        yield return new WaitForSeconds(time);
        aleaToStop.OnEnd();
    }
}
