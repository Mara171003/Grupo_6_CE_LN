using System.ComponentModel.DataAnnotations;

namespace Grupo_6_CE_LN.Models
{
    public class Rutas
    {
        public int IdRuta {  get; set; }
        public string NombreRuta    { get; set; }
        public string Descripcion { get; set; }
        //Id para lista de paradas
        public int IdParada { get; set; }
        //Id para lista de horarios
        public int IdHorario { get; set; }
        // Activo = 1, Inactivo = 0
        public bool Estado  { get; set; }
        public DateTime FechaRegistro { get; set; }
        //Nombre del usuario que realiza el registro
        public string UsuarioRegistro { get; set; }

        //Para el listado de Paradas y Horarios se llama sus modelos respectivos 

    }
}
