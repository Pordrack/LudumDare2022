using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AleaScriptableObject", order = 1)]
public class AleaTemplate : ScriptableObject
{
    public string AleaName;
    public string AleaDescription;
    public int Probability; //Mettre au dessus de 1 pour plus de proba, marche comme les coeffficients a l'école
    public AleaScript aleaScript;
    public float BaseMediumTime; //Le temps moyen que va durer l'alea, au début (peut être multiplié par l'invoqueur)
}

public abstract class AleaScript
{
    public float TimeLeft;

    public void Update(float deltaTime)
    {
        TimeLeft -= deltaTime;
        if (TimeLeft < 0)
        {
            OnEnd();
            return;
        }
    }
    public abstract void OnTrigger();
    public abstract void OnEnd();
}