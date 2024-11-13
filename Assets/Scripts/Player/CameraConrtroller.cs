using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(1, 7, -5);

    [Header("Rotation")]
    public float xRotation; 
    public float yRotation; 
    public float zRotation; 

    private void LateUpdate()
    {
        Vector3 targetPosition = player.position + offset;
        transform.position = targetPosition;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation); 
    }
}
