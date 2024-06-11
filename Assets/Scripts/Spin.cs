using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spin : MonoBehaviour
{
    public float rotationSpeed = 100f; 

    private Vector2 rotationInput;

    void Update()
    {
        
        rotationInput = Gamepad.current?.rightStick.ReadValue() ?? Vector2.zero;

        
        transform.Rotate(Vector3.up, rotationInput.x * rotationSpeed * Time.deltaTime);

        
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }
    }
}
