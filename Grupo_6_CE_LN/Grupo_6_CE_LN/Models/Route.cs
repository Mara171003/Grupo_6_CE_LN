using System;
using System.Collections.Generic;

namespace Grupo_6_CE_LN.Models
{
    public class Route
    {
        public int Id { get; set; }  // ID único para la ruta
        public string RouteCode { get; set; }  // Código de la ruta
        public string Name { get; set; }  // Nombre de la ruta
        public string Description { get; set; }  // Descripción de la ruta
        public List<string> Stops { get; set; }  // Lista de paradas de la ruta
        public List<string> Schedules { get; set; }  // Lista de horarios
        public string Status { get; set; }  // Estado de la ruta (Activo/Inactivo)
        public DateTime RegistrationDate { get; set; }  // Fecha de registro
        public string RegisteredBy { get; set; }  // Usuario que registró la ruta
    }
}
