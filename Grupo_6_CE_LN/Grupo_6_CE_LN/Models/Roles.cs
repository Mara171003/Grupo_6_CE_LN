using System.ComponentModel.DataAnnotations;

namespace Grupo_6_CE_LN.Models
{
    public class Roles
    {

    [Key]
    public int ID_Rol { get; set; }

    [Required]
    [StringLength(50)]
    public string NombreRol { get; set; }

    public ICollection<Usuarios> Usuarios { get; set; } = new List<Usuarios>();
    }
}