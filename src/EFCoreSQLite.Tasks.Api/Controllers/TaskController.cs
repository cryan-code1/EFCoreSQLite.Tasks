using EFCoreSQLite.Tasks.Api.Context;
using EFCoreSQLite.Tasks.Api.Models;
using EFCoreSQLite.Tasks.Api.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSQLite.Tasks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController(DataContext context) : Controller
{
    private readonly DataContext _context = context;

    #region Post

    [HttpPost]
    public async Task<ActionResult<List<TaskModel>>> Add(TaskModel model)
    {
        model.CreationDate = DateTime.Now;
       
        _context.Tasks.Add(model);
        await _context.SaveChangesAsync();

        return Ok("Task created successfully.");
    }

    #endregion

    #region Get

    [HttpGet]
    public async Task<ActionResult<List<TaskModel>>> GetAll() 
    { 
        return Ok(await _context.Tasks.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TaskModel>> GetById(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
     
        if (task == null)
        {
            return NotFound("Task not found.");
        }
        
        return Ok(task);
    }

    [HttpGet("status/{status}")]
    public async Task<ActionResult<List<TaskModel>>> GetByStatus([FromRoute] TaskModelStatus status)
    {
        var tasks = await _context.Tasks.Where(t => t.Status == status).ToListAsync();

        if (tasks.Count == 0)
        {
            return NotFound($"No tasks found with status '{status}'.");
        }

        return Ok(tasks);
    }

    [HttpGet("count")]
    public async Task<ActionResult> GetTasksCount()
    {
        var total = await _context.Tasks.CountAsync();
        var completed = await _context.Tasks.CountAsync(t => t.Status == TaskModelStatus.Completed);
        var pending = total - completed;

        return Ok(new
        {
            Total = total,
            Completed = completed,
            Pending = pending
        });
    }

    #endregion

    #region Put
    
    [HttpPut("{id}")]
    public async Task<ActionResult<List<TaskModel>>> Update(int id, TaskModelStatus newStatus)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound("Task not found.");
        }

        task.Status = newStatus;
        task.ConclusionDate = DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok("Task updated successfully.");
    }

    #endregion

    #region Delete
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<List<TaskModel>>> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound("Task not found.");
        }

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return Ok("Task deleted successfully.");
    }

    #endregion
}