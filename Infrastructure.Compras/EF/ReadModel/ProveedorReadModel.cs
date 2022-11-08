using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Compras.EF.ReadModel
{
    internal class ProveedorReadModel
    {
        [Key]
        [Column("proveedorId")]
        public Guid Id { get; set; }

        [Required]
        [Column("nombreCompleto")]
        [MaxLength(250)]
        public string NombreCompleto { get; set; }

        [Required]
        [Column("ubicacion")]
        [MaxLength(250)]
        public string Ubicacion { get; set; }

        public ProveedorReadModel()
        {
            NombreCompleto = "";
            Ubicacion = "";
        }
    }
}
