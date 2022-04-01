using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void onShowPopup(GameObject popup){
        popup.SetActive(true);
    }

    public void onHidePopup(GameObject popup){
        popup.SetActive(false);
    }


    public void onQuit(){
        Application.Quit();
    }
}
