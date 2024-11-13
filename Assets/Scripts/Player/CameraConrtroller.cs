using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraConrtroller : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(1, 8, -8);
    public float cameraSpeed = 0.2f;


    void LateUpdate()
    {
        Vector3 cameraPosition = player.position + offset;
        Vector3 movePosition = Vector3.Lerp(transform.position, cameraPosition, cameraSpeed);
        transform.position = movePosition;

        transform.LookAt(player);
    }
}
