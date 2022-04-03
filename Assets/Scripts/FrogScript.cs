using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private float cooldown = 0; //Le cooldown actuel avant qu'il puisse retuer un insect
    public float TimeBetweenEating; //Le temps qu'il doit attendre entre chaque meurtre.
    public float LifeTime = 10;//Le temps qu'il lui reste a vivre
    public float LifeTimeGainedPerInsect = 1;//La vie que lui redonne chaque insecte
    new public ParticleSystem particleSystem;
    public LayerMask layerMask;
    public List<BugScript> targetList;

    void Update()
    {
        LifeTime -= Time.deltaTime;
        cooldown-= Time.deltaTime;
        if (LifeTime < 0)
        {
            Die();
            return;
        }

        if (cooldown > 0)
        {
            return;
        }

        foreach(BugScript bug in targetList)
        {
            Eat(bug);
        }
    }

    public void Eat(BugScript target)
    {
        Debug.Log("I will try to eat");
        
        //On vérifie qu'il n'y a aucun obstacle entre les elemnts
        Vector2 fromPosition = transform.position;
        Vector2 toPosition = target.transform.position;
        Vector2 direction = toPosition - fromPosition;

        //On calcul aussi l'angle et la distance pour après
        float angle = Mathf.Atan2(toPosition.y - fromPosition.y, toPosition.x - fromPosition.x);
        float distance = direction.magnitude;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Mathf.Infinity, layerMask);

        //Si on ne touche pas la cible, y'as eu un bug, on annule tout
        if (hit.collider == null)
            return;

        //Si on touche une cible et que c'est pas l'ennemi, c'est qu'un obstacle se trouvais entre les 2
        if (hit.collider.tag != "Bug")
            return;

        //On va aussi fire le particle system avec le bon angle
        particleSystem.transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg*angle-transform.eulerAngles.z);
        particleSystem.Emit(1);


        //Sinon, c'est bon, on peut tuer la cible
        var main = particleSystem.main;
        float time = 0; //distance / main.startSpeed.constant;
        StartCoroutine(target.DelayedKill(time));
        //cooldown = TimeBetweenEating;
    }

    void Die()
    {
        cooldown = 1000; //On mange plus rien là
        GetComponent<Collider2D>().enabled = false; //On passe a travers le sol pour disparaitre peinard
        Destroy(gameObject, 5);
        LifeTime = 1000; //On évite de se faire appeler a chaque frame comme ça
    }
}
