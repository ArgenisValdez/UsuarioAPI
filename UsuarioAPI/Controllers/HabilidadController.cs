using Microsoft.AspNetCore.Mvc;
using UsuarioAPI.Helpers;
using UsuarioAPI.Models;
using UsuarioAPI.Services;

namespace UsuarioAPI.Controllers;

[ApiController]
[Route("api/usuario/{usuarioId}/[controller]")]
public class HabilidadController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Habilidad>> GetHabilidades(int usuarioId)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);

        return Ok(usuario.Habilidades);
    }

    [HttpGet("{habilidadId}")]
    public ActionResult<Habilidad> GetHabilidad(int usuarioId, int habilidadId)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);

        var habilidad = usuario.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

        if (habilidad == null)
            return NotFound(Mensajes.Habilidad.NotFound);

            return Ok(habilidad);

    } 

    [HttpPost]
    public ActionResult<Habilidad> PostHabilidad(int usuarioId, HabilidadInsert habilidadInsert)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);

        var habilidadExistente = usuario.Habilidades.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

        if(habilidadExistente != null)
            return BadRequest(Mensajes.Habilidad.NombreExistente);
        
        var maxHabilidad = usuario.Habilidades.Max(h=> h.Id);


        var habilidadNueva = new Habilidad(){
            Id = maxHabilidad + 1,
            Nombre = habilidadInsert.Nombre,
            Potencia = habilidadInsert.Potencia
        };

        usuario.Habilidades.Add(habilidadNueva);

        return CreatedAtAction(nameof(GetHabilidad),
            new { usuarioId = usuarioId, habilidadId =habilidadNueva.Id},
            habilidadNueva
            );

    } 
    
    [HttpPut("{habilidadId}")]
    public ActionResult<Habilidad> PutHabilidad(int usuarioId, int habilidadId, HabilidadInsert habilidadInsert)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);

        var habilidadExistente = usuario.Habilidades?.FirstOrDefault(h => h.Nombre == habilidadInsert.Nombre);

        if (habilidadExistente == null)
            return NotFound(Mensajes.Habilidad.NotFound);
        
        var habilidadMismoNombre = usuario.Habilidades?
            .FirstOrDefault(h => h.Id != habilidadId && h.Nombre == habilidadInsert.Nombre);

        if(habilidadMismoNombre != null)
            return BadRequest(Mensajes.Habilidad.NombreExistente);   
        
        habilidadExistente.Nombre = habilidadInsert.Nombre;
        habilidadExistente.Potencia = habilidadInsert.Potencia;

        return NoContent();
    } 
    
    [HttpDelete("{habilidadId}")]
    public ActionResult<Habilidad> DeleteHabilidad(int usuarioId, int habilidadId)
    {
        var usuario = UsuarioDataStore.Current.Usuarios.FirstOrDefault(x=> x.Id ==usuarioId);
        
        if (usuario == null)
            return NotFound(Mensajes.Usuario.NotFound);

        var habilidadExistente = usuario.Habilidades?.FirstOrDefault(h => h.Id == habilidadId);

        if (habilidadExistente == null)
            return NotFound(Mensajes.Habilidad.NotFound);
        
        usuario.Habilidades?.Remove(habilidadExistente);

        return NoContent();
    } 
    
}