using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public float chaseRange = 10.0f;
    public float shootingRange = 5.0f;
    public float maxDistanceFromPlayer = 3.0f; 
    public float timeBetweenShots = 1.0f; 
    public float bulletLifetime = 3.0f; 
    public GameObject bulletPrefab;
    public Transform shootingPoint;
    public Transform[] waypoints;
    private int waypointIndex = 0;
    private bool isShooting = false;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            
            Vector3 directionToPlayer = player.position - transform.position;
            Vector3 desiredPosition = player.position - directionToPlayer.normalized * maxDistanceFromPlayer;

            
            agent.SetDestination(desiredPosition);

            
            if (distanceToPlayer < shootingRange && !isShooting)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, (player.position - transform.position), out hit, shootingRange))
                {
                    if (hit.transform == player)
                    {
                        StartCoroutine(Shoot());
                    }
                }
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (Vector3.Distance(transform.position, waypoints[waypointIndex].position) < 1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
        agent.SetDestination(waypoints[waypointIndex].position);
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
        bulletRigidbody.velocity = (player.position - shootingPoint.position).normalized * 20f;
        
        
        Destroy(bullet, bulletLifetime);

        yield return new WaitForSeconds(timeBetweenShots);
        isShooting = false;
    }
}


