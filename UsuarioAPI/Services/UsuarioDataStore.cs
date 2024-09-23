using UsuarioAPI.Models;

namespace UsuarioAPI.Services;

public class UsuarioDataStore
{
    public List<Usuario> Usuarios { get; set; }

    public static UsuarioDataStore Current { get;} = new UsuarioDataStore(); 

    public UsuarioDataStore()
    {
        Usuarios = new List<Usuario>(){
            new Usuario(){
                Id = 1,
                Nombre = "Pedro Jose",
                Apellido = "Abreu",
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.Epotencia.Moderado
                    }
                }
            },
            new Usuario(){
                Id = 2,
                Nombre = "Superman Jesus",
                Apellido = "Correa",
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Saltar",
                        Potencia = Habilidad.Epotencia.Moderado
                    },
                    new Habilidad(){
                        Id = 2,
                        Nombre = "Super Velocidad",
                        Potencia = Habilidad.Epotencia.Intenso
                    },
                    new Habilidad(){
                        Id = 3,
                        Nombre = "Volar",
                        Potencia = Habilidad.Epotencia.RePotente
                    }
                }
            },
            new Usuario(){
                Id = 3,
                Nombre = "Enrrique",
                Apellido = "Castillo",
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Cantar",
                        Potencia = Habilidad.Epotencia.Moderado
                    },
                    new Habilidad(){
                        Id = 2,
                        Nombre = "Trotar",
                        Potencia = Habilidad.Epotencia.Suave
                    },
                    new Habilidad(){
                        Id = 3,
                        Nombre = "Dormir",
                        Potencia = Habilidad.Epotencia.RePotente
                    }
                }
            },
            new Usuario(){
                Id = 4,
                Nombre = "Jimmy La Leyenda",
                Apellido = "Almonte",
                Habilidades = new List<Habilidad>(){
                    new Habilidad(){
                        Id = 1,
                        Nombre = "Jugar Softball",
                        Potencia = Habilidad.Epotencia.RePotente
                    },
                    new Habilidad(){
                        Id = 2,
                        Nombre = "Hablar ingles",
                        Potencia = Habilidad.Epotencia.Suave
                    },
                    new Habilidad(){
                        Id = 3,
                        Nombre = "Dormir",
                        Potencia = Habilidad.Epotencia.RePotente
                    },
                    new Habilidad(){
                        Id = 4,
                        Nombre = "Jugar al counter",
                        Potencia = Habilidad.Epotencia.Suave
                    }
                }
            }
        };
    }
}