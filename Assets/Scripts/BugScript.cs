using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugScript : MonoBehaviour
{
    public EdgeCollider2D PathToFollow;
    public float Speed;
    private int currentPoint=0; //Le dernier point qu'on a atteint
    public int minWaterDropped = 3;
    public int maxWaterDropped = 5;
    private float? previousAngle = null; //L'angle entre l'insecte et le prochain point a la frame pr�c�dente
    public int Life = 1;//Le nombre de clic restant pour le tuer
    public AudioSource hurtSound;
    public AudioSource deathSound;

    public AudioSource[] spawnSounds;
    // Start is called before the first frame update
    void Start()
    {
        Vector2 target = PathToFollow.points[0];
        //On pense a eventuellement flip le bidule
        target.x *= PathToFollow.transform.localScale.x;
        target += (Vector2)PathToFollow.transform.position;
        
        //On commence par se positionner sur le d�but du chemin
        transform.position = target;

        int randomIndex = Random.Range(0, spawnSounds.Length);
        spawnSounds[randomIndex].Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Si on est arriv� a la fin du point, on s'arr�te
        if (currentPoint >= PathToFollow.points.Length - 1)
            return;

        //On cible le point apr�s le dernier atteint
        Vector2 target = PathToFollow.points[currentPoint + 1];
        //On pense a eventuellement flip le bidule
        target.x *= PathToFollow.transform.localScale.x;
        target += (Vector2)PathToFollow.transform.position;

        float angle = Mathf.Atan2(target.y - transform.position.y, target.x - transform.position.x);
        float distFromTarget = Mathf.Sqrt(Mathf.Pow(target.x - transform.position.x, 2) + Mathf.Pow(target.x - transform.position.x, 2));
        //if (target.x-transform.position.x != null)
        //{
        //    if (Mathf.Abs(angle - (float)previousAngle) >= 0.9 * Mathf.PI)
        //    {
        //        currentPoint += 1;
        //        return;
        //    }
        //}
        //Une fois la cible attente, on passe au prochain point
        if (distFromTarget < 0.1f)
        {
            currentPoint += 1;
            return;
        }

        Vector2 newPosition = new Vector2(transform.position.x,transform.position.y);
        newPosition.x += Mathf.Cos(angle)*Speed*Time.deltaTime;
        newPosition.y += Mathf.Sin(angle) * Speed * Time.deltaTime;
        float rotation = angle;
        transform.position = newPosition;

        // De cette fa�on, on s'assure que l'angle est toujours compris entre 0 et PI ! (merci Mr. Thirioux)
        //rotation = Mathf.Atan(Mathf.Tan(rotation));

        //On oublie pas d'inverser de l'insecte si besoin
        float xMult = 1;
        if(rotation>0.5*Mathf.PI && rotation<1.5*Mathf.PI)
        {
            xMult = -1;
        }
        float absoluteScale = Mathf.Abs(transform.localScale.y);
        transform.localScale = new Vector3(transform.localScale.x, xMult * absoluteScale, transform.localScale.z);
        transform.eulerAngles = new Vector3(0,0,Mathf.Rad2Deg*rotation);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Une fois le coeur atteint, on tue la plante
        if (other.tag == "Heart")
        {
            other.transform.gameObject.GetComponentInParent<PlantScript>().Die();
            Destroy(gameObject);
            //Et on se suicide
        }
        //Si on est dans la zone d'une tourelle grenouille, on doit regarder si on se fait tuer
        if (other.tag == "FrogTurret")
        {
            other.gameObject.GetComponentInParent<FrogScript>().targetList.Add(this);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "FrogTurret")
        {
            other.gameObject.GetComponentInParent<FrogScript>().targetList.Remove(this);
        }
    }

    private void OnMouseDown()
    {
        //On emet les particles de blessures
        gameObject.GetComponentInChildren<ParticleSystem>().Emit(15);
        //On enleve une vie
        Life -= 1;
        //Et si on est pas mort, c'est tout
        if (Life > 0)
        {
            hurtSound.Stop();
            hurtSound.Play();
            return;
        }
            
        //Sinon, on prepare la mort
        Kill();
    }

    public void Kill()
    {
        gameObject.GetComponent<Animator>().SetBool("WillDie", true);
        gameObject.GetComponentInChildren<ParticleSystem>().Emit(30);
        WaterCanScript.Instance.WaterReserve += Random.Range(minWaterDropped, maxWaterDropped);
        WaterCanScript.Instance.WaterReserve = Mathf.Clamp(WaterCanScript.Instance.WaterReserve, 0, WaterCanScript.Instance.WaterMaxReserve);
        Destroy(gameObject, 0.5f);

        hurtSound.Stop();
        deathSound.Play();
    }

    public IEnumerator DelayedKill(float time)
    {
        yield return new WaitForSeconds(time);
        Kill();
    }
}
