using System;

public class Score
{
    public event Action<int> OnScoreChanged;
    public int CurrentScore
    {
        get => _score;
        set
        {
            _score = value;
            OnScoreChanged(_score);
        }
    }
    private int _score;
}
