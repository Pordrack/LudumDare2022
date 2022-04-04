using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuySlotScript : MonoBehaviour
{
    public float Price;
    public string Name;
    public Text PriceText;
    public Text NameText;


    // Start is called before the first frame update
    void Start()
    {
        PriceText.text = Mathf.FloorToInt(Price).ToString();
        NameText.text = Name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
