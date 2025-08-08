using EFCoreSQLite.Tasks.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSQLite.Tasks.Api.Context;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<TaskModel> Tasks { get; set; } = null!;
}