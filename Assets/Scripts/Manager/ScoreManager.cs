using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance {  get; private set; } 

    public int score = 0;
    public int scoreIncrease = 1;
    private float elapsedTime = 0f; 

    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); 
        }
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 1f)
        {
            score += scoreIncrease;
            elapsedTime = 0f;

            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }
        }
    }
}