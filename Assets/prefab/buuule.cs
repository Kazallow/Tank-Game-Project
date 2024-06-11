using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buuule : MonoBehaviour
{
    private int layerIndex;

    void Start()
    {
        layerIndex = LayerMask.NameToLayer("WhatIsPlayer");
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.layer == layerIndex)
        {
            
            TankHealth tankHealth = collision.gameObject.GetComponent<TankHealth>();
            if (tankHealth != null)
            {
                tankHealth.TakeDamage(1); 
            }
            
            
            Destroy(gameObject);
        }
    }
}
