using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
public class JsonRecordRepository : IRecordsRepository
{
    [JsonProperty]
    public List<Record> _records { get; } = new List<Record>();
    private readonly string _path;
    public JsonRecordRepository(string path)
    {
        _path = path;
        if (File.Exists(path))
        {
            var json = File.ReadAllText(_path);
            _records = JsonConvert.DeserializeObject<List<Record>>(json);
        }
    }

    public IEnumerable<Record> Records => _records;
    public void AddRecord(Record newRecord)
    {
        _records.Add(newRecord);
        Save();
    }
    public void RemoveRecord(Record recordToDelete)
    {
        _records.Remove(recordToDelete);
        Save();
    }
    private void Save()
    {
        var json = JsonConvert.SerializeObject(_records);
        File.WriteAllText(_path, json);
    }
}
