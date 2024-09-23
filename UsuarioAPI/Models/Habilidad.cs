namespace UsuarioAPI.Models;

public class Habilidad
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public Epotencia Potencia { get; set; }
    
    public enum Epotencia
    {
        Suave,
        Moderado,
        Intenso,
        RePotente,
        Exremo
    }
}