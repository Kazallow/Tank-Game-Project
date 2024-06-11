using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CombinedRotation : MonoBehaviour
{
    public Transform target; 
    public float followDistance = 5f; 
    public float rotationSpeed = 100f; 

    private Vector2 rotationInput;
    private float yaw = 0f;
    private float pitch = 0f;

    void Update()
    {
        rotationInput = Gamepad.current?.rightStick.ReadValue() ?? Vector2.zero;
        
        if (Input.GetKey(KeyCode.Q))
        {
            yaw += rotationSpeed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.E))
        {
            yaw -= rotationSpeed * Time.deltaTime; 
        }

        if (Input.GetKey(KeyCode.R))
        {
            pitch += rotationSpeed * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.F))
        {
            pitch -= rotationSpeed * Time.deltaTime; 
        }

        yaw += rotationInput.x * rotationSpeed * Time.deltaTime;
        pitch -= rotationInput.y * rotationSpeed * Time.deltaTime; 

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        if (target != null)
        {
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
            Vector3 desiredPosition = target.position - (rotation * Vector3.forward * followDistance);
            transform.position = desiredPosition;
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = Quaternion.Euler(pitch, yaw, 0f);
        }
    }
}
