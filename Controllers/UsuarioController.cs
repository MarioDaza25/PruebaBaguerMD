using Microsoft.AspNetCore.Mvc;
using PruebaBaguerMD.Models;
using PruebaBaguerMD.Models.Interfaces;

namespace PruebaBaguerMD.Controllers;

   
public class UsuarioController : BaseApiController
{
    
    private readonly IGeneric<Usuario> _usuarioService;

    public UsuarioController(IGeneric<Usuario> usuarioService)
    {
        _usuarioService = usuarioService;
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetAllUsuarios()
    {
        var usuarios = await _usuarioService.GetAllAsync();
        return Ok(usuarios);
    }


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Usuario>> CreateUsuario(Usuario usuario)
    {
        _usuarioService.Add(usuario);
        await _usuarioService.SaveAsync();
        return CreatedAtAction(nameof(CreateUsuario), new { id = usuario.Id }, usuario);
    }


    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateUsuario(int id, Usuario usuario)
    {
        if (id != usuario.Id)
        {
            return BadRequest();
        }
        _usuarioService.Update(usuario);
        await _usuarioService.SaveAsync();
        return NoContent();
    }
    

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        var usuario = await _usuarioService.GetByIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        _usuarioService.Remove(usuario);
        await _usuarioService.SaveAsync();
        return NoContent();
    }

    
}
