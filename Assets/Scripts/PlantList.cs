using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//On utilise cette classe pour stocker toutes les plantes du niveau, utilie pour la camera 
//Ou savoir quand on est morts
public class PlantList : MonoBehaviour
{
    private static PlantList _instance;

    public static PlantList Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PlantList>();
            }

            return _instance;
        }
    }

    public List<PlantScript> Plants;

    public string DeathSceneName;

    void Start()
    {
        
    }

    void Update()
    {
        foreach(PlantScript plant in Plants)
        {
            if (!plant.IsDead)
                return;
        }
        SceneManager.LoadScene(DeathSceneName);
    }
}
