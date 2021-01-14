using System;

public struct Record : IComparable<Record>
{
    public string Username { get; set; }
    public int Score { get; set; }

    public int CompareTo(Record other)
    {
        return -Score.CompareTo(other.Score);
    }
}
