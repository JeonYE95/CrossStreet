using UnityEngine;

public class CarController : MonoBehaviour
{
    private CarData carData;
    private ObjectPool pool;
    [SerializeField] private float spawntime;

    private float elapsedTime;

    private void OnEnable()
    {
        elapsedTime = 0f;
    }

    private void Update()
    {
        if (carData != null)
        {
            transform.Translate(Vector3.forward * carData.speed * Time.deltaTime);
        }

        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawntime)
        {
            ReturnPool();
        }
    }

    public void Initialize(CarData data, ObjectPool objectPool)
    {
        carData = data;
        gameObject.name = carData.model;
        pool = objectPool;
    }

    private void ReturnPool()
    {
        if (pool != null)
        {
            pool.ReturnObject(gameObject);
        }
    }
}