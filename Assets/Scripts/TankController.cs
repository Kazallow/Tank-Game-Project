using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 100.0f;
    public GameObject[] leftTrackWheels;
    public GameObject[] rightTrackWheels;
    public float wheelRotationSpeed = 5.0f;

    private Rigidbody tankRigidbody;
    private float moveInput;
    private float turnInput;

    void Start()
    {
        tankRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        
        moveInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");

        
        AnimateWheels();
    }

    void FixedUpdate()
    {
        
        MoveTank();
        TurnTank();
    }

    void MoveTank()
    {
        Vector3 movement = transform.forward * moveInput * moveSpeed * Time.fixedDeltaTime;
        tankRigidbody.MovePosition(tankRigidbody.position + movement);
    }

    void TurnTank()
    {
        float turn = turnInput * rotationSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        tankRigidbody.MoveRotation(tankRigidbody.rotation * turnRotation);
    }

    void AnimateWheels()
    {
        float wheelRotation = moveInput * wheelRotationSpeed;
        
        
        foreach (GameObject wheel in leftTrackWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(Vector3.right, wheelRotation);
            }
        }

        
        foreach (GameObject wheel in rightTrackWheels)
        {
            if (wheel != null)
            {
                wheel.transform.Rotate(Vector3.right, wheelRotation);
            }
        }
    }
}

