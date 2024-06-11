using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform tank; 
    public Transform cannon; 

    public float smoothSpeed = 0.125f; 
    public Vector3 offset; 

    private void LateUpdate()
    {
        Vector3 desiredPosition = tank.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        transform.rotation = Quaternion.Lerp(transform.rotation, cannon.rotation, smoothSpeed);
    }
}