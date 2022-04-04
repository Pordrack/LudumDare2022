using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    public GameObject howToPlayObject;
    public void Switch()
    {
        howToPlayObject.SetActive(!howToPlayObject.activeSelf);
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }
}
