using EFCoreSQLite.Tasks.Api.Models.Enums;

namespace EFCoreSQLite.Tasks.Api.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; } = string.Empty;
    public TaskModelStatus Status { get; set; } = TaskModelStatus.Created;
    public DateTime CreationDate { get; set; }
    public DateTime? ConclusionDate { get; set; }
}
