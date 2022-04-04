using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChronoScript : MonoBehaviour
{
    public float TimeLeft;
    public string SceneToLoad;
    public TMP_Text TimerText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeLeft -= Time.deltaTime;
        if (TimeLeft <= 0)
        {
            SceneManager.LoadScene(SceneToLoad);
        }

        int minutesNumber = Mathf.FloorToInt(TimeLeft / 60);
        int secondsNumber = Mathf.FloorToInt(TimeLeft % 60);

        string secondsString = secondsNumber.ToString();
        if (secondsString.Length < 2)
        {
            secondsString = "0" + secondsString;
        }

        string minutesString = minutesNumber.ToString();
        if (minutesString.Length < 2)
        {
            minutesString = "0" + minutesString;
        }

        TimerText.text = minutesString + ":" + secondsString;
    }
}
