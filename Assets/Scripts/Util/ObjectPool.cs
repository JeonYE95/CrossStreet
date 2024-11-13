using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public int carPoolSize = 10;

    private Dictionary<GameObject, Queue<GameObject>> poolDictionary = new Dictionary<GameObject, Queue<GameObject>>();
    private void Start()
    {
        foreach (GameObject carPrefab in carPrefabs)
        {
            Queue<GameObject> carQueue = new Queue<GameObject>();

            for (int i = 0; i < carPoolSize; i++)
            {
                GameObject carInstance = Instantiate(carPrefab);
                carInstance.SetActive(false);
                carQueue.Enqueue(carInstance);
            }

            poolDictionary.Add(carPrefab, carQueue);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < carPrefabs.Length; i++)
        {
            GameObject selectPrefab = carPrefabs[Random.Range(0, carPrefabs.Length)];
            Queue<GameObject> carQueue = poolDictionary[selectPrefab];

            if (carQueue.Count > 0)
            {
                GameObject obj = carQueue.Dequeue();
                obj.SetActive(true);
                return obj;
            }
        }

        return null;
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);

        foreach (var pair in poolDictionary)
        {
            if (pair.Key.name == obj.name.Replace("(Clone)", "").Trim())
            {
                pair.Value.Enqueue(obj);
                break;
            }
        }
    }
}