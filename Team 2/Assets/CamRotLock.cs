using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamRotLock : MonoBehaviour
{
    Transform transform;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
        rotation= transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotation;
    }
    
    //EarlyUpdate 
}
