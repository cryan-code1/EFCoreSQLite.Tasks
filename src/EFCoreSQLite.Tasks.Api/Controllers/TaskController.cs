using EFCoreSQLite.Tasks.Api.Context;
using EFCoreSQLite.Tasks.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCoreSQLite.Tasks.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TaskController(DataContext context) : Controller
{
    private readonly DataContext _context = context;

    [HttpPost]
    public async Task<ActionResult<List<TaskModel>>> Add(TaskModel model)
    {
        model.CreationDate = DateTime.Now;
       
        _context.Tasks.Add(model);
        await _context.SaveChangesAsync();

        return Ok("Task created successfully.");
    }

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

    [HttpPut("{id}")]
    public async Task<ActionResult<List<TaskModel>>> Update(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
        {
            return NotFound("Task not found.");
        }

        task.Done = true;
        task.ConclusionDate = DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok("Task updated successfully.");
    }

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
}