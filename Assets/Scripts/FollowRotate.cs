using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAndRotate : MonoBehaviour
{
    public Transform target; 
    public float distance = 5f; 
    public float sensitivity = 2f; 

    private float yaw = 0f;
    private float pitch = 0f;

    void LateUpdate()
    {
        if (target == null)
            return;

        
        yaw += sensitivity * Input.GetAxis("Mouse X");
        pitch -= sensitivity * Input.GetAxis("Mouse Y");

        
        pitch = Mathf.Clamp(pitch, -90f, 90f);

        
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);

        
        Vector3 desiredPosition = target.position - (rotation * Vector3.forward * distance);

        
        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}
