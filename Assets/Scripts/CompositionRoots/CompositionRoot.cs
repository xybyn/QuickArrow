using System;
using UnityEngine;

public class CompositionRoot : MonoBehaviour
{
    private void Awake()
    {
        var arrowController = FindObjectOfType<PlayerController>();
        var inputReader = FindObjectOfType<KeyboardInputReader>();
        var obstacleCreator = FindObjectOfType<ObstacleCreator>();
        var scoreCounter = FindObjectOfType<ScoreCounter>();
        var scorePresentation = FindObjectOfType<ScorePresentation>();
        var gameFlow = FindObjectOfType<GameFlow>();
        var playerMotor = FindObjectOfType<PlayerMotor>();
        var recordsRepository = new JsonRecordRepository(Environment.CurrentDirectory+  @"records.json");
        var recordTableService = new RecordTableService(recordsRepository);
        var playerRepos = new JsonPlayerReposotory (Environment.CurrentDirectory + @"player.json");
        var playerService = new PlayerService(playerRepos);
        var recordsApiService = new RecordsApiService(playerService);
        arrowController.InputReader = inputReader;
        var score = new Score();
        scoreCounter.Score = score;
        obstacleCreator.Score = score;
        scorePresentation.Score = score;
        gameFlow.Score = score;
        gameFlow.RecordsApiService = recordsApiService;
        gameFlow.RecordTableService = recordTableService;
        playerMotor.OnGameStarted += scoreCounter.OnGameStartRecieved;
        playerMotor.OnGameOver += scoreCounter.OnGameOverRecieved;
        playerMotor.OnGameOver += gameFlow.OnGameOverRecieved;
    }
}
