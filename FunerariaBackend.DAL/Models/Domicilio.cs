using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaBackend.DAL.Models
{
    public class Domicilio: IModel
    {
        public int Id { get; set; }

        [Required]
        public int IdMunicipio { get; set; }

        [Required(AllowEmptyStrings =false)]
        [MaxLength(200)]
        public string Calle { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        public string NumeroExterior { get; set; }

        [MaxLength(10)]
        public string NumeroInterior { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(200)]
        public string Colonia { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(10)]
        public string CodigoPostal { get; set; }

        [MaxLength(400)]
        public string EntreCalles { get; set; }

        [MaxLength(10)]
        public string Latitud { get; set; }

        [MaxLength(10)]
        public string Longitud { get; set; }

        [Required]
        public int IdPropietario { get; set; }


        [ForeignKey("IdMunicipio")]
        public Municipio Municipio { get; set; }

        [ForeignKey("IdPropietario")]
        public Persona Persona { get; set; }
    }
}
