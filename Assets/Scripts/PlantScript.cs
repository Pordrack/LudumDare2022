using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public float WaterLevel = 10;
    private bool IsDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //On pert de l'eau en fonction du climat
        WaterLevel -= Time.deltaTime * ClimateScript.Instance.DrynessRate;
    }

    public void Water(float waterAmount)
    {
        if (IsDead)
        {
            return;
        }
        WaterLevel += waterAmount;
    }
}
