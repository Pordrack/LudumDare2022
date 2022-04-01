using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSkipper : MonoBehaviour
{
    public string SceneToLoad;
    public float TimeBeforeSkip;
    public string[] buttonsToSkip;

    private float cooldown;

    void Start()
    {
        cooldown = 0.5f;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        TimeBeforeSkip -= Time.deltaTime;

        //Si le cooldown est pas écouléç a sert a rien de continuer, autant s'arrêter là
        if (cooldown > 0)
            return;

        //Si un des boutons est pressé, ou si le temps est écoule, on passe à la prochaine scène
        foreach (string input in buttonsToSkip)
        {
            if (Input.GetButtonDown(input) || TimeBeforeSkip<=0)
            {
                SceneManager.LoadScene(SceneToLoad);
            }
        }
    }
}
