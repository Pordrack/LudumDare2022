using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogScript : MonoBehaviour
{
    private float cooldown = 0; //Le cooldown actuel avant qu'il puisse retuer un insect
    public float TimeBetweenEating; //Le temps qu'il doit attendre entre chaque meurtre.
    public float LifeTime = 10;//Le temps qu'il lui reste a vivre
    public float LifeTimeGainedPerInsect = 1;//La vie que lui redonne chaque insecte

    void Update()
    {
        LifeTime -= Time.deltaTime;
        cooldown-= Time.deltaTime;
        if (LifeTime < 0)
        {
            Die();
            return;
        }
    }

    public void Eat(BugScript target)
    {
        //On vérifie qu'il n'y a aucun obstacle entre les elemnts
        Vector3 fromPosition = transform.position;
        Vector3 toPosition = target.transform.position;
        Vector3 direction = toPosition - fromPosition;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction);

        //Si on ne touche pas la cible, y'as eu un bug, on annule tout
        if (hit.collider == null)
            return;

        //Si on touche une cible et que c'est pas l'ennemi, c'est qu'un obstacle se trouvais entre les 2
        if (hit.collider.tag != "Bug")
            return;

        //Sinon, c'est bon, on peut tuer la cible
        target.Kill();     
    }

    void Die()
    {
        cooldown = 1000; //On mange plus rien là
        GetComponent<Collider2D>().enabled = false; //On passe a travers le sol pour disparaitre peinard
        Destroy(gameObject, 5);
        LifeTime = 1000; //On évite de se faire appeler a chaque frame comme ça
    }
}
