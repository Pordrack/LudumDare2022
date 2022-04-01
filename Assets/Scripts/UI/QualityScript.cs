using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class QualityScript : MonoBehaviour
{
    public Slider slider;
    public Text displayer;
    string[] names;
    // Start is called before the first frame update
    void Start()
    {
        names = QualitySettings.names;
        displayer.text=names[QualitySettings.GetQualityLevel()];
        slider.maxValue=names.Length-1;
        slider.value=QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    public void changeQuality(){
        int lvl=Mathf.FloorToInt(slider.value);
        //Debug.Log("lvl : "+lvl+" vlaue : "+slider.value);
        QualitySettings.SetQualityLevel(lvl);
        displayer.text=names[QualitySettings.GetQualityLevel()];
    }
}
