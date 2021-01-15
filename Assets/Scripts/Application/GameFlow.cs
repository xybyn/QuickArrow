using System;
using System.Collections;
using UnityEngine;

public class GameFlow : MonoBehaviour, IGameOverReciever, IGameInitializedSender
{
    public Score Score;
    public GameObject GameOverMenu;
    public event Action OnGameInitialized;
    public RecordTableService RecordTableService;
    public RecordsApiService RecordsApiService;
    public void OnGameOverRecieved()
    {

        Time.timeScale = 0;
        var record = new Record
        {
            Score = Score.CurrentScore
        };
        RecordTableService.Add(record);
        StartCoroutine(SendResults());
        GameOverMenu.SetActive(true);
        GameOverMenu.GetComponent<GameOverMenu>().SetText($"Your score: {Score.CurrentScore}");
    }
    private void Start()
    {
        OnGameInitialized?.Invoke();
        Time.timeScale = 1;
    }
    private IEnumerator SendResults()
    {
        var record = new Record
        {
            Score = Score.CurrentScore
        };
        var resul = RecordsApiService.AddRecordAsync(record);
        yield return null;
    }
}
