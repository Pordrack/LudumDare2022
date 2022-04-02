using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimateScript : MonoBehaviour
{
    private static ClimateScript _instance;
    public static ClimateScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ClimateScript>();
            }

            return _instance;
        }
    }

    public float DrynessRate = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
