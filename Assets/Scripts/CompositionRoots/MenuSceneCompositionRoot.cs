using UnityEngine;

public class MenuSceneCompositionRoot : MonoBehaviour
{
    public RecordsMenu RecordsMenu;
    private void Awake()
    {

        var recordsRepository = new JsonRecordRepository(@"Assets\Records\records.json");
        var recordTableService = new RecordTableService(recordsRepository);
        RecordsMenu.RecordTableService = recordTableService;
    }
}
