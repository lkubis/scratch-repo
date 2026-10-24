using Scratch.Tasks;
using Xunit;

namespace Scratch.Tasks.Tests;

public sealed class TaskListTests
{
    [Fact]
    public void Added_tasks_get_consecutive_ids_and_a_trimmed_title()
    {
        var list = new TaskList();

        var first = list.Add("  write the report ");
        var second = list.Add("review it");

        Assert.Equal((1, "write the report"), (first.Id, first.Title));
        Assert.Equal(2, second.Id);
        Assert.Equal(2, list.Items.Count);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    public void A_blank_title_is_rejected(string title) => Assert.Throws<ArgumentException>(() => new TaskList().Add(title));

    [Fact]
    public void Completing_a_task_marks_it_done()
    {
        var list = new TaskList();
        var task = list.Add("ship it");

        Assert.True(list.Complete(task.Id));

        Assert.True(list.Items[0].Done);
    }

    [Fact]
    public void Completing_an_unknown_task_reports_false_and_changes_nothing()
    {
        var list = new TaskList();
        list.Add("only task");

        Assert.False(list.Complete(99));

        Assert.False(list.Items[0].Done);
    }
}
