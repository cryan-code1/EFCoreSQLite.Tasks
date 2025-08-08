namespace EFCoreSQLite.Tasks.Api.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Done { get; set; } = false;
    public DateTime CreationDate { get; set; }
    public DateTime ConclusionDate { get; set; }
}