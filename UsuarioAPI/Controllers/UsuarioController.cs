using System.IO.Compression;
using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Helpers;
using UsuarioAPI.Models;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return Ok(UsuarioDataStore.Current.Usuarios);
    }

    [HttpGet("{usuarioId}")]
    public ActionResult<Usuario> GetUsuario(int usuarioId)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);
        
        return Ok(usuario); 
    }

    [HttpPost]
    public ActionResult<Usuario> PostUsuario(UsuarioInsert usuarioInsert)
    {
        var maxUsuarioId = UsuarioDataStore.Current.Usuarios.Max(x=> x.Id);


        var usuarioNuevo = new Usuario(){
            Id = maxUsuarioId + 1,
            Nombre = usuarioInsert.Nombre,
            Apellido = usuarioInsert.Apellido
        };

        UsuarioDataStore.Current.Usuarios.Add(usuarioNuevo);
 
        return CreatedAtAction(nameof(GetUsuario),
            new { usuarioId = usuarioNuevo.Id},
            usuarioNuevo
            );
    }

    [HttpPut("{usuarioId}")]
    public ActionResult<Usuario>PutUsuario([FromRoute] int usuarioId, [FromBody] UsuarioInsert usuarioInsert)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);

        usuario.Nombre = usuarioInsert.Nombre;
        usuario.Apellido = usuarioInsert.Apellido;

        return NoContent();
    }

    [HttpDelete("{usuarioId}")]
    public ActionResult<Usuario>DeleteUsuario(int usuarioId)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);

        UsuarioDataStore.Current.Usuarios.Remove(usuario);
        return NoContent();
    }
}