using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideItself : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void onHide(GameObject element){
        element.SetActive(false);
    }

    public void onShow(GameObject element){
        element.SetActive(true);
    }
}
