using System;

[Serializable]
public class QuestData
{
    private string name;
    private bool complete;

    public QuestData(string name, bool complete)
    {
        this.name = name;
        this.complete = complete;
    }

    public bool IsComplete()
    {
        return this.complete;
    }
}