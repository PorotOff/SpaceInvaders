using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private int score = 0;
    private Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<Text>();
    }

    private void OnEnable()
    {
        MonsterDie.OnMonsterDie += AddScore;
    }
    private void OnDisable()
    {
        MonsterDie.OnMonsterDie -= AddScore;
    }

    private void AddScore(int score)
    {
        this.score += score;
        PrintScore();
    }
    private void PrintScore()
    {
        scoreText.text = $"score {score}";
    }
    
    public int GetCurrentScore()
    {
        return score;
    }
}
