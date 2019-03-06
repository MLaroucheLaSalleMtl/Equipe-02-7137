using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CamRotLock : MonoBehaviour
{
    Quaternion rotation;
    [SerializeField] Transform rail;
    [SerializeField] float maxZoom = -5;
    [SerializeField] float minZoom = -12;
    // Start is called before the first frame update
    void Start()
    {
        rotation= transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = rotation;
        if(rail.localPosition.z<= maxZoom && rail.localPosition.z>= minZoom)
        {
            rail.transform.localPosition=new Vector3(rail.transform.localPosition.x, rail.transform.localPosition.y, rail.transform.localPosition.z+ Input.GetAxis("Zoom"));
        }
        if(rail.localPosition.z > maxZoom)
        {
            rail.transform.localPosition = new Vector3(rail.transform.localPosition.x, rail.transform.localPosition.y, maxZoom);
        }
        else if(rail.localPosition.z < minZoom)
        {
            rail.transform.localPosition = new Vector3(rail.transform.localPosition.x, rail.transform.localPosition.y, minZoom);
        }
    }
    
}
