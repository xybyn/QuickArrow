using System;
using UnityEngine;

public class MenuSceneCompositionRoot : MonoBehaviour
{
    public RecordsMenu RecordsMenu;
    public SettingsMenu SettingsMenu;
    private void Awake()
    {
        var playerRepo = new JsonPlayerReposotory(Environment.CurrentDirectory + @"player.json");
        var playerService = new PlayerService(playerRepo);
        var recordsRepository = new JsonRecordRepository(Environment.CurrentDirectory + @"records.json");
        var recordTableService = new RecordTableService(recordsRepository);
        RecordsMenu.RecordTableService = recordTableService;
        SettingsMenu.PlayerService = playerService;
    }
}
