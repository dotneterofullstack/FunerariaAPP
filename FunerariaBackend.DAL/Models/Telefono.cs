using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaBackend.DAL.Models
{
    public class Telefono: IModel
    {
        public int Id { get; set; }

        [Required]
        public int IdTipoTelefono { get; set; }

        [Required]
        public int IdPropietario { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(maximumLength:10, MinimumLength = 10)]
        public string NumeroTelefono { get; set; }

        [MaxLength(5)]
        public string Extension { get; set; }

        [ForeignKey("IdPropietario")]
        public Persona Persona { get; set; }

        [ForeignKey("IdTipoTelefono")]
        public TipoTelefono TipoTelefono { get; set; }
    }
}
