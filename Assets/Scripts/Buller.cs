using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
          int layerIndex = LayerMask.NameToLayer("WhatIsPlayer");

    
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


