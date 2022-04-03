using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEvent : AleaScript
{
    public int minAmountOfBugs = 10;
    public int maxAmountOfBugs = 30;
    public override void OnEnd()
    {
        
    }

    public override void OnTrigger()
    {
        //On tire au sort le nombre d'insecte qu'on va faire spawner
        int amountOfBugs = Random.Range(minAmountOfBugs, maxAmountOfBugs);

        //On fait spawner tous ces insectes en les étalants sur une seconde de temps;
        for(int i = 0; i < amountOfBugs; i++)
        {
            Invoke("Spawn", Random.Range(0f, 1f));
        }
    }

    public void Spawn()
    {
        BugSpawnerScript.Instance.Spawn();
    }
}
