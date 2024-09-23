using static UsuarioAPI.Models.Habilidad;

namespace UsuarioAPI.Models;

public class HabilidadInsert
{
    public string Nombre { get; set; } = string.Empty;
    public Epotencia Potencia { get; set; }
}