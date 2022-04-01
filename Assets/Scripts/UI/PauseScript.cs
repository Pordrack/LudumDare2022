using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    static bool pauseOn=false;
    public GameObject popup;
    private static PauseScript _instance;

    // Start is called before the first frame update
    void Start()
    {
        onContinue();
    }

    public static PauseScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<PauseScript>();
            }

            return _instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Pause")){
            if(pauseOn){
                onContinue();
            }else{
                OnPause();  
            }
            //Debug.Log("pauseOn=" + pauseOn.ToString()); 
        }
    }

    public void onContinue()
    {
        StartCoroutine(onContinue(0));
    }

    public IEnumerator onContinue(float time){

        yield return new WaitForSecondsRealtime(time);
        pauseOn = false;
        Time.timeScale = 1;
        Invoke("unfreezeTime", 0.01f);
        popup.SetActive(false);
    }

    public void OnPause()
    {
        Time.timeScale = 0;
        Invoke("freezeTime", 0.01f); //Pour une raison inconnu, la premiere fois qu'on met pause, ça s'annule tout seul apres 1 frame, mais le popup reste là, donc là c'est du rafistolage pur et dur. 
        popup.SetActive(true);
        pauseOn = true;
    }

    public void onReturnToMenu(){
        SceneManager.LoadScene("MenuScene");
    }

    private void freezeTime(){
        Time.timeScale=0;
    }

    private void unfreezeTime()
    {
        Time.timeScale = 1;
    }

    //Si un autre script veut annuler la pause (exemple: un script ou le joueur peut appuyer sur echap)
    public void CancelPause()
    {
        StartCoroutine(onContinue(0.05f));
    }
}
