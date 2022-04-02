using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantScript : MonoBehaviour
{
    public float WaterLevel = 10;
    public float WaterMaxLevel = 20;
    
    public Image WaterBar;
    float WaterBarY = -3;

    private bool IsDead = false;
    // Start is called before the first frame update
    void Start()
    {
        WaterBar.transform.position = new Vector3(transform.position.x, transform.position.y + WaterBarY, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(WaterLevel + " water left in plant");

        //On pert de l'eau en fonction du climat
        WaterLevel -= Time.deltaTime * ClimateScript.Instance.DrynessRate;

        //On ne peut pas avoir + d'eau que la valeur de WaterMaxLevel
        if (WaterLevel > WaterMaxLevel) { WaterLevel = WaterMaxLevel; }

        WaterBarFiller();
    }

    void WaterBarFiller() //remplissage visible de la jauge d'eau
    {
        WaterBar.fillAmount = WaterLevel / WaterMaxLevel;
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
