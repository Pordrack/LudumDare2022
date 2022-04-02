using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterCanScript : MonoBehaviour
{

    private static WaterCanScript _instance;

    public static WaterCanScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<WaterCanScript>();
            }

            return _instance;
        }
    }

    private Vector3 mousePosition;
    public GameObject particleSystem;

    public float WaterReserve = 40;
    public float WaterMaxReserve = 100;
    public float WaterPerSecond = 5;
    public LayerMask layerMask;
    public Image WaterBar;
    float WaterBarY = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(WaterReserve + " water left in can");

        //l'objet suit les mouvements de la souris
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

        //la jauge d'eau suit les mouvements de la souris
        WaterBar.transform.position = new Vector3(mousePosition.x, mousePosition.y + WaterBarY, mousePosition.z);

        WaterBarFiller();

        particleSystem.SetActive(Input.GetMouseButton(0) && WaterReserve > 0);
        if (!Input.GetMouseButton(0))
            return;

        if (WaterReserve <= 0)
            return;

        particleSystem.SetActive(true);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up,Mathf.Infinity,layerMask);

        // If it hits something...
        if (hit.collider != null)
        {
            if(hit.collider.tag=="Plant" || hit.collider.tag == "Pot")
            {
                PlantScript plantScript = hit.transform.parent.gameObject.GetComponent<PlantScript>();
                plantScript.Water(WaterPerSecond * Time.deltaTime);
                this.WaterReserve -= WaterPerSecond * Time.deltaTime;
            }   
        }
    }

    void WaterBarFiller() //remplissage visible de la jauge d'eau
    {
        WaterBar.fillAmount = WaterReserve / WaterMaxReserve;
    }
}
