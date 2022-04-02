using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantScript : MonoBehaviour
{
    private float initialWaterLevel;
    public float WaterLevel = 10;
<<<<<<< Updated upstream
=======
<<<<<<< HEAD
>>>>>>> Stashed changes
    public float WaterMaxLevel = 20;
    
    public Image WaterBar;
    float WaterBarY = -3;

<<<<<<< Updated upstream
=======
=======
    public float MaxWaterLevel = 15;
    public SpriteRenderer plantSpriteRenderer;
    public Sprite[] Images; //Les images representant les differents niveaux de secheresse de la plante.
    public Sprite DeathImage; //L'image de la plante morte
>>>>>>> e9ae25876912b0f44ce7a3734e14883050b29bf2
>>>>>>> Stashed changes
    private bool IsDead = false;

    // Start is called before the first frame update
    void Start()
    {
<<<<<<< Updated upstream
        WaterBar.transform.position = new Vector3(transform.position.x, transform.position.y + WaterBarY, transform.position.z);
=======
<<<<<<< HEAD
        WaterBar.transform.position = new Vector3(transform.position.x, transform.position.y + WaterBarY, transform.position.z);
=======
        initialWaterLevel = WaterLevel;

>>>>>>> e9ae25876912b0f44ce7a3734e14883050b29bf2
>>>>>>> Stashed changes
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< Updated upstream
        Debug.Log(WaterLevel + " water left in plant");
=======
<<<<<<< HEAD
        Debug.Log(WaterLevel + " water left in plant");
=======
        if (IsDead)
        {
            return;
        }
>>>>>>> e9ae25876912b0f44ce7a3734e14883050b29bf2
>>>>>>> Stashed changes

        //On pert de l'eau en fonction du climat
        WaterLevel -= Time.deltaTime * ClimateScript.Instance.DrynessRate;

<<<<<<< Updated upstream
=======
<<<<<<< HEAD
>>>>>>> Stashed changes
        //On ne peut pas avoir + d'eau que la valeur de WaterMaxLevel
        if (WaterLevel > WaterMaxLevel) { WaterLevel = WaterMaxLevel; }

        WaterBarFiller();
    }

    void WaterBarFiller() //remplissage visible de la jauge d'eau
    {
        WaterBar.fillAmount = WaterLevel / WaterMaxLevel;
<<<<<<< Updated upstream
=======
=======
        if (WaterLevel <= 0)
        {
            Die();
            return;
        }

        //On change de sprite en fonction du pourcentage d'eau restant
        float percentage = WaterLevel/MaxWaterLevel;
        int currentSprite = (int)Mathf.Floor((1-percentage) * (Images.Length));
        Debug.Log(percentage);
        plantSpriteRenderer.sprite = Images[currentSprite];
        //On regarde si on doit mourir
    }

    public void Die()
    {
        IsDead = true;
        plantSpriteRenderer.sprite = DeathImage;
>>>>>>> e9ae25876912b0f44ce7a3734e14883050b29bf2
>>>>>>> Stashed changes
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
