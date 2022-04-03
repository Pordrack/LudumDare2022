using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/AleaScriptableObject", order = 1)]
public class AleaTemplate : ScriptableObject
{
    public string AleaName;
    public string AleaDescription;
    public int Probability; //Mettre au dessus de 1 pour plus de proba, marche comme les coeffficients a l'école
    public AleaScript script;
    public float BaseMediumTime; //Le temps moyen que va durer l'alea, au début (peut être multiplié par l'invoqueur)
}

public abstract class AleaScript : MonoBehaviour
{
    public float TimeLeft;

    public abstract void OnTrigger();
    public abstract void OnEnd();
}