using System.Collections;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public bool moveCamera = true;                      // Whether the camera should be moved by this script.    
    public float smoothing = 7f;                        // Smoothing applied during Slerp, higher is smoother but slower.
    public Transform playerPosition;                    // Reference to the player's Transform to aim at.

    public float minZoom = 0f;
    public float maxZoom = 15f;
    public float zoomSpeed = 1f;
    public float currentZoom = 5f;

    public Vector3 offset = new Vector3(0f, 1.5f, 0f);
    // change this value to get desired smoothness
    public float SmoothTime = 0.3f;

    private Vector3 velocity = Vector3.zero;

    private IEnumerator Start ()
    {
        // If the camera shouldn't move, do nothing.
        if(!moveCamera)
            yield break;

        // Wait a single frame to ensure all other Starts are called first.
        yield return null;
    }

    void Update()
    {
        // zoom on scroll wheel 
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    // LateUpdate is used so that all position updates have happened before the camera aims.
    private void LateUpdate ()
    {
        // If the camer shouldn't move, do nothing.
        if (!moveCamera)
            return;

        Vector3 targetPosition = playerPosition.position + offset * currentZoom;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        Vector3 lookAt = new Vector3(transform.position.x, playerPosition.transform.position.y, playerPosition.position.z);
        transform.LookAt(lookAt);


    }
}
