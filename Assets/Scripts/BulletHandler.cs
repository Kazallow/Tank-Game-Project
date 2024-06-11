using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class BulletHandler : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;
    public InputActionAsset inputActionAsset; 

    private InputAction fireAction; 
    void Awake()
    {
        
        fireAction = inputActionAsset.FindAction("Fire", throwIfNotFound: true); 
        fireAction.performed += _ => SpawnObject(); 
        fireAction.Enable(); 
    }

    void OnDestroy()
    {
       
        fireAction.Disable();
    }


    void SpawnObject()
    {
        Debug.Log("SpawnObject called"); 
        Vector3 spawnPosition = transform.position;
        Quaternion spawnRotation = Quaternion.identity;
        Vector3 localDirection = transform.TransformDirection(Vector3.forward);
        Vector3 velocity = localDirection * launchSpeed;
        GameObject newObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);

        Rigidbody rb = newObject.GetComponent<Rigidbody>();
        rb.velocity = velocity;
    }
}