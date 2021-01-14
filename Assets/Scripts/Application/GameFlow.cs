using System;
using UnityEngine;

public class GameFlow : MonoBehaviour, IGameOverReciever, IGameInitializedSender
{
    public Score Score;
    public GameObject GameOverMenu;
    public event Action OnGameInitialized;
    public RecordTableService RecordTableService;

    public void OnGameOverRecieved()
    {

        Time.timeScale = 0;
        RecordTableService.Add(new Record
        {
            Score = Score.CurrentScore
        });
        GameOverMenu.SetActive(true);
        GameOverMenu.GetComponent<GameOverMenu>().SetText($"Your score: {Score.CurrentScore}");
    }
    private void Start()
    {
        OnGameInitialized?.Invoke();
        Time.timeScale = 1;
    }
}
