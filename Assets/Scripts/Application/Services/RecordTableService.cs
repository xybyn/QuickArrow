using System.Linq;
public class RecordTableService
{
    public RecordTable RecordTable
    {
        get
        {
            var recordTable = new RecordTable();

            var records = _repos._records;
            records.Sort();
            int n = records.Count <= MAX_RECORDS ? records.Count : MAX_RECORDS;
            for (int i = 0; i < records.Count; i++)
            {
                recordTable.Records[i] = records[i];
            }
            return recordTable;
        }
    }
    
    private readonly IRecordsRepository _repos;
    
    private const int MAX_RECORDS = 5;
    public RecordTableService(IRecordsRepository repos)
    {
        _repos = repos;
    }
    //limits record repository
    public void Add(Record newRecord)
    {
        _repos.AddRecord(newRecord);
        var records = _repos._records;
        records.Sort();
        if (_repos._records.Count> MAX_RECORDS)
        {
            _repos.RemoveRecord(records.Last());
        }
    }
}


