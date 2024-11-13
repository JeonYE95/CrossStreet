using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoad : MonoBehaviour
{
    public GameObject mapPrefab;
    public Transform player;

    void Start()
    {
        Vector3 spawnPosition = player.position;
        Instantiate(mapPrefab, spawnPosition, Quaternion.identity);
    }
}
