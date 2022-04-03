using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//La camera qui peut switcher entre les plantes
public class CameraScript : MonoBehaviour
{
    private int index = 0;
    public Transform target = null;
    //l'écart entre la camera et la cible (plante)
    private Vector3 offset;

    private static CameraScript _instance;

    public static CameraScript Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<CameraScript>();
            }

            return _instance;
        }
    }

    private void Start()
    {
        target = PlantList.Instance.Plants[0].transform;
        offset = transform.position - target.position;
    }

    public void MoveTarget(int diff)
    {
        index+=diff;
        if (index >= PlantList.Instance.Plants.Count)
        {
            index = 0;
        }

        if (index < 0)
        {
            index = PlantList.Instance.Plants.Count-1;
        }
        target = PlantList.Instance.Plants[index].transform;

        transform.position = target.position + offset;
    }
}
