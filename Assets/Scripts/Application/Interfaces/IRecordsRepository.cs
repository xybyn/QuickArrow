using System.Collections.Generic;

public interface IRecordsRepository
{
    List<Record> _records { get; }
    void AddRecord(Record newRecord);
    void RemoveRecord(Record recordToRemove);
}
