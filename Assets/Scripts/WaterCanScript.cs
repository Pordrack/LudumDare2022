using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCanScript : MonoBehaviour
{
    private Vector3 mousePosition;
    public GameObject particleSystem;
    public float WaterReserve = 40;
    public float WaterPerSecond = 5;
    public LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0;
        transform.position = mousePosition;

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
}
