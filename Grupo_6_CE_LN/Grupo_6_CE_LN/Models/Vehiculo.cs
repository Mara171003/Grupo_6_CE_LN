using System.ComponentModel.DataAnnotations;

namespace Grupo_6_CE_LN.Models
{
    public class Vehiculo
    {
        public int Id { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int CapacidadPasajeros { get; set; }
        public string Estado { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now; // Se genera automáticamente
        public string UsuarioRegistro { get; set; } // Se asigna en el código
    }
}
