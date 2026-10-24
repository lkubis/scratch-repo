namespace Scratch.Tasks;

/// <summary>A tiny in-memory task list. It exists only so the AI platform's worker has something small to change, build and test.</summary>
public sealed class TaskList
{
    private readonly List<TaskItem> _items = [];

    public IReadOnlyList<TaskItem> Items => _items;

    public TaskItem Add(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("A task needs a title.", nameof(title));
        }

        var item = new TaskItem(_items.Count + 1, title.Trim());
        _items.Add(item);
        return item;
    }

    public bool Complete(int id)
    {
        var index = _items.FindIndex(x => x.Id == id);
        if (index < 0)
        {
            return false;
        }

        _items[index] = _items[index] with { Done = true };
        return true;
    }
}
