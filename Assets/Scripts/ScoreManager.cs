using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private void Awake()
    {
        Instance = this;

    }
    public void AddScore(int value)
    {
        score += value;
        scoreText.text = score.ToString();
        if (score >= 160)
        {
            MainMenu.Instance.GameOver("");
        }
    }

}//class
