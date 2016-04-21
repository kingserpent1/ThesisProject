using UnityEngine;
using System.Collections;

public class FollowDock : MonoBehaviour 
{
    public Transform target;            // The position that that camera will be following.
    public float smoothing = 5f;        // The speed with which the camera will be following.
    public float speed = 0.01f;			//The Speed with which the camera changes direction


    //private Transform pivot;

    Vector3 offset;                     // The initial offset from the target.


    void Start()
    {
        // Calculate the initial offset.
        //pivot = new GameObject ().transform;
        //transform.parent = target;
        offset = transform.position - target.position;
    }


    void FixedUpdate()
    {
        FollowPlayer();
        //TurnTowardsPlayer ();
    }


    void FollowPlayer()
    {
        // Create a postion the camera is aiming for based on the offset from the target.
        Vector3 targetCamPos = target.position + offset;
        // Smoothly interpolate between the camera's current position and it's target position.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
