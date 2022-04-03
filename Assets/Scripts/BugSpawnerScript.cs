using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawnerScript : MonoBehaviour
{
    private static BugSpawnerScript _instance;

    public static BugSpawnerScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<BugSpawnerScript>();
            }

            return _instance;
        }
    }

    public List<EdgeCollider2D> PathsToFollow;
    public GameObject InsectPrefab;
    //Le temps moyen entre l'apparition de chaque insecte
    public float SpawnTime = 5;
    //La variation que subit aleatoirement chaque temps
    public float SpawnTimeSpread = 2;
    //Le rate auquel la durée baisse
    public float SpawnAcceleration = 0.001f;

    //Les mêmes mais pour les vitesses à laquelle les insectes spawnent.
    public float BugSpeed = 5;
    public float BugSpeedSpread = 2;
    public float BugSpeedAcceleration = 0.001f;

    //Les valeurs de drop des insectes
    public int minWaterDopped = 3;
    public int maxWaterDropped = 6;

    //Les valeurs de vie des insectes
    public int minBugLife = 1;
    public int maxBugLife = 3;

    private float spawnTimer;

    private void Awake()
    {
        PathsToFollow = new List<EdgeCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = SpawnTime + Random.Range(-SpawnTimeSpread, SpawnTimeSpread);
    }

    // Update is called once per frame
    void Update()
    {
        //On fait defiler le temps et on applique les accelerations aux variables
        spawnTimer -= Time.deltaTime;
        SpawnTime -= Time.deltaTime * SpawnAcceleration;
        BugSpeed += Time.deltaTime * BugSpeedAcceleration;
        BugSpeedSpread+=0.3f* Time.deltaTime * BugSpeedAcceleration;

        if (spawnTimer > 0)
            return;

        Spawn();
    }

    public void Spawn()
    {
        //On fait spawner un nouveau mob et on lui donne un chemin au pif dans la liste
        GameObject newBug = Object.Instantiate(InsectPrefab);
        BugScript newBugScript = newBug.GetComponent<BugScript>();
        newBugScript.PathToFollow = PathsToFollow[Random.Range(0, PathsToFollow.Count)];

        //Si la plante est morte on tire un nouveau chemin
        //while (newBugScript.PathToFollow.GetComponentInParent<PlantScript>().IsDead)
        //{
        //    newBugScript.PathToFollow = PathsToFollow[Random.Range(0, PathsToFollow.Count)];
        //}

        //Puis on lui donne sa vitesse random
        newBugScript.Speed += BugSpeed + Random.Range(-BugSpeedSpread, BugSpeedSpread);
        //Et sa vie random
        newBugScript.Life = Random.Range(minBugLife, maxBugLife);
        //Et on oublie pas de reset le timer !
        spawnTimer = SpawnTime + Random.Range(-SpawnTimeSpread, SpawnTimeSpread);
        newBugScript.minWaterDropped = minWaterDopped;
        newBugScript.maxWaterDropped = maxWaterDropped;
    }
}
