using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;

namespace Grupo_6_CE_LN.Models
{
    public class Usuarios
    {
        [Key]
        public int ID_Usuario { get; set; }

        [Required]
        [StringLength(50)]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(100)]
        public string NombreCompleto { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }

        public int ID_Rol { get; set; }

        [ForeignKey("ID_Rol")]
        public Roles Roles { get; set; }

        public ICollection<Boletos> Boletos { get; set; } = new List<Boletos>();
    }
}