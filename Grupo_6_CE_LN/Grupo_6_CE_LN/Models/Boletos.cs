using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Grupo_6_CE_LN.Models
{
    public class Boletos
    {

    [Key]
    public int ID_Boleto { get; set; }

    [Required]
    public int ID_Usuario { get; set; }

    [Required]
    public int IdRuta { get; set; }

    [Required]
    public int Id { get; set; }

    [Required]
    public DateTime FechaHoraCompra { get; set; } = DateTime.Now;

    [Required]
    public int Asiento { get; set; }

    [Required]
    [StringLength(20)]
    public string Estado { get; set; }

    [ForeignKey("ID_Usuario")]
    public Usuarios Usuarios { get; set; }

    }
}