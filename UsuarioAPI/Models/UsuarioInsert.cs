using System.ComponentModel.DataAnnotations;

namespace UsuarioAPI.Models;

public class UsuarioInsert
{
    [Required]
    [MaxLength(50)]
    public string Nombre { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(50)]
    public string Apellido { get; set; } = string.Empty;
}