using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            GameManager.Instance.GameOver();
        }
        else if (other.CompareTag("ClearZone"))
        {
            GameManager.Instance.GameClear();
        }
    }
}