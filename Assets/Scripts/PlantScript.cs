using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantScript : MonoBehaviour
{
    private float initialWaterLevel;
    public float WaterLevel = 10;
    public Image WaterBar;
    float WaterBarY = -3;

    public float MaxWaterLevel = 15;
    public SpriteRenderer plantSpriteRenderer;
    public Sprite[] Images; //Les images representant les differents niveaux de secheresse de la plante.
    public Sprite DeathImage; //L'image de la plante morte

    private bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
        initialWaterLevel = WaterLevel;

        WaterBar.transform.position = new Vector3(transform.position.x, transform.position.y + WaterBarY, transform.position.z);
        WaterBar.transform.position = new Vector3(transform.position.x, transform.position.y + WaterBarY, transform.position.z);
        initialWaterLevel = WaterLevel;

    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead)
        {
            return;
        }
        //On pert de l'eau en fonction du climat
        WaterLevel -= Time.deltaTime * ClimateScript.Instance.DrynessRate;

        //On ne peut pas avoir + d'eau que la valeur de WaterMaxLevel
        if (WaterLevel > WaterMaxLevel) { WaterLevel = WaterMaxLevel; }

        WaterBarFiller();

        //On change de sprite en fonction du pourcentage d'eau restant
        float percentage = WaterLevel/MaxWaterLevel;
        int currentSprite = (int)Mathf.Floor((1-percentage) * (Images.Length));
        Debug.Log(percentage);
        plantSpriteRenderer.sprite = Images[currentSprite];
        //On regarde si on doit mourir
        if (WaterLevel <= 0)
        {
            Die();
            return;
        }
    }

    void WaterBarFiller() //remplissage visible de la jauge d'eau
    {
        WaterBar.fillAmount = WaterLevel / WaterMaxLevel;     
    }

    public void Die()
    {
        IsDead = true;
        plantSpriteRenderer.sprite = DeathImage;
    }

    public void Water(float waterAmount)
    {
        if (IsDead)
        {
            return;
        }
        WaterLevel += waterAmount;

        if (WaterLevel > MaxWaterLevel)
        {
            WaterLevel = MaxWaterLevel;
        }
    }
}
