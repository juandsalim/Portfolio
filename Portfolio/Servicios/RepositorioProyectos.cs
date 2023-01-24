using Portfolio.Models;

namespace Portfolio.Servicios
{
    public class RepositorioProyectos
    {

        public List<Proyecto> ObtenerProyectos()
        {
            return new List<Proyecto>() { new Proyecto
            {
                Titulo= "TattooStudio",
                Descripcion= "Sistema de gestion de turnos y profesionales para estudios de tatuajes, realizado en .NET 4.8",
                Link= "https://github.com/juandsalim/TattoStudio.git",
                ImagenURL= "/imagenes/tattostudio.png",

                
            },
            new Proyecto
            {
                Titulo= "WebPersonal",
                Descripcion= "Modelo para un web personal, desarrolado en python y django framework",
                Link= "https://github.com/juandsalim/webpersonal",
                ImagenURL= "/imagenes/webpersonal.png",
            }

                
            
            };

        }
    }
}
