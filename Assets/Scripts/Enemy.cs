using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 20; 

    void Update()
    {
        if (health <= 0)
        {
            Die(); 
        }
    }

    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Bullet") 
        {
            TakeDamage(1); 
        }
    }

    
    void TakeDamage(int damage)
    {
        health -= damage;
    }

    
    void Die()
    {
        GetComponent<Animator>().SetBool("IsDead", true); 
        GetComponent<Rigidbody>().isKinematic = true; 
        GetComponent<Collider>().enabled = false; 
        Destroy(gameObject, 2f); 
    }
}
