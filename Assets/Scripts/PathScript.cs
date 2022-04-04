using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    PlantScript plantScript;
    // Start is called before the first frame update
    void Start()
    {
        plantScript = GetComponentInParent<PlantScript>();
        BugSpawnerScript.Instance.PathsToFollow.Add(gameObject.GetComponent<EdgeCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        if (!plantScript.IsDead)
            return;
        BugSpawnerScript.Instance.PathsToFollow.Remove(gameObject.GetComponent<EdgeCollider2D>());
        this.enabled = false;
        return;
    }
}
