using HeliumBackend.interfaces;
using HeliumBackend.models;
using Microsoft.AspNetCore.Mvc;

namespace HeliumBackend.controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController  : ControllerBase
{

    private readonly IUserService _UserService;
    public UserController(IUserService userService)
    {
        _UserService = userService;       
    }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll()
        => Ok(await _UserService.GetAll());
       
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<User>> GetById(string id)
    {
        var user = await _UserService.GetById(id);
       
        return user is null ? NotFound() : Ok(user);        
    }
    [HttpPost]
    public async Task<IActionResult> Create(User user)
    {
        var createdUser = await _UserService.Create(user);     
        Console.WriteLine("posted user "+user.Username );
        return createdUser is null
            ? throw new Exception("User creation failed")
            : CreatedAtAction(nameof(GetById),
                new { id = createdUser.Id }, createdUser);
    }
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update(string id, User updatedUser)
    {
        var queriedUser = await _UserService.GetById(id);
            
        if (queriedUser is null)
        {
            return NotFound();
        }
        await _UserService.Update(id, updatedUser);
            
        return NoContent();
    }
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete(string id)
    {
        var user = await _UserService.GetById(id);
        if (user is null)
        {
            return NotFound();
        }
        await _UserService.Delete(id);
        return NoContent();
    }
}