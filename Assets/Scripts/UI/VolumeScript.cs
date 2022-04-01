using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{

    public Slider slider;

    void Start()
    {
        slider.value=AudioListener.volume*100;
    }

    public void changeVolume(){
        AudioListener.volume=slider.value/100;
    }
}
