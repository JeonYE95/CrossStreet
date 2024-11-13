using UnityEngine;

[CreateAssetMenu(fileName = "NewCarData", menuName = "Car/CarData")]
public class CarData : ScriptableObject
{
    public float speed;
    public string model;
}