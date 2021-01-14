using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorePresentation : MonoBehaviour
{
    public Score Score;
    public TMPro.TextMeshProUGUI ScoreText;

    private void Start()
    {
        Score.OnScoreChanged += UpdateScore;
    }

    private void OnDestroy()
    {
        Score.OnScoreChanged -= UpdateScore;
    }

    private void UpdateScore(int score)
    {
        ScoreText.text = $"Score: {score}";
    }
}
