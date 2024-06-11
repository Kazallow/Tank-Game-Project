using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet2 : MonoBehaviour
{
    public float launchSpeed = 75.0f;
    public GameObject objectPrefab;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SpawnObject();
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = transform.position;
    Quaternion spawnRotation = Quaternion.identity;

    
    Vector3 localDirection = transform.TransformDirection(Vector3.forward); 
    Vector3 velocity = localDirection * launchSpeed;
    GameObject newObject = Instantiate(objectPrefab, spawnPosition, spawnRotation);

    Rigidbody rb = newObject.GetComponent<Rigidbody>();
    rb.velocity = velocity;
    }
}