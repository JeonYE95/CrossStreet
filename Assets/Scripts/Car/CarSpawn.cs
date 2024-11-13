using System.Collections;
using UnityEngine;

public class CarSpawn : MonoBehaviour
{
    public ObjectPool carPool;
    public CarData[] carDatas;
    public Transform[] spawnPoint;
    public float minSpawnInterval = 4f;
    public float maxSpawnInterval = 6f;

    private void Start()
    {
        StartCoroutine(SpawnCars());
    }

    private IEnumerator SpawnCars()
    {
        while (true)
        {
            float spawnInterval = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(spawnInterval);

            Transform selectSpawnPoint = spawnPoint[Random.Range(0, spawnPoint.Length)];

            GameObject carObejct = carPool.GetObject();
            if (carObejct != null)
            {
                CarController carController = carObejct.GetComponent<CarController>();
                CarData randomCarData = carDatas[Random.Range(0, carDatas.Length)];

                carController.transform.position = selectSpawnPoint.position;
                carController.transform.rotation = selectSpawnPoint.rotation;

                carController.Initialize(randomCarData, carPool);
            }
        }
    }
}