using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BugSpawnerScript.Instance.PathsToFollow.Add(gameObject.GetComponent<EdgeCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
