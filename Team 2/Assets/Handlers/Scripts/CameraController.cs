using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// @author Samuel Paquette
/// @date 17 MARS 2019
/// @description Controls the camera smoothly
/// </summary>
public class CameraController : MonoBehaviour
{

    //the transform of the player that the camera is gonna look at
    public Transform playerTransform;
    //the zoom of the camera (scroll wheel)
    public float currentZoom = 10f;
    //The offset the camera has from the pivot for the center of rotation
    public Vector3 cameraOffset;
    //the amount of elevation for the look at (if we dont add an elevation, camera will look at the feet of the player)
    public float elevation = 2f;
    //the speed we zoom with the scroll wheel
    public float zoomSpeed = 4f;
    //min zoom
    public float minZoom = 5f;
    //max zoom
    public float maxZoom = 15f;
    //speed that we rotate the camera
    private float rotationSpeed = 150f;
    //the current rotation we have
    private float currentRotation = 0f;

    private void Update ()
    {
        //zoom with scroll wheel
        currentZoom -= Input.GetAxis("Zoom") * zoomSpeed;
        //we dont want to go above max and below min zoom so we clamp the value
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
        //get the input to rotate the camera
        currentRotation -= Input.GetAxis("CameraRotation") * rotationSpeed * Time.deltaTime;
    }

    private void LateUpdate ()
    {
        //place the camera
        transform.position = playerTransform.position - cameraOffset * currentZoom;
        //camera looks towards the player
        transform.LookAt(playerTransform.position + Vector3.up * elevation);
        //rotate the camera around the player if needed
        transform.RotateAround(playerTransform.position, Vector3.up, currentRotation);
    }
}
