using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaBackend.DAL.Models
{
    public class Asesor: Persona
    {
        [Required]
        public int IdCargo { get; set; }
        public int? IdReferidoPor { get; set; }

        [Required(AllowEmptyStrings =false)]
        [Index(IsUnique = true)]
        public string Codigo { get; set; }

        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }

        [ForeignKey("IdReferidoPor")]
        public Asesor ReferidoPorAsesor { get; set; }

        [InverseProperty("ReferidoPorAsesor")]
        public List<Asesor> AsesoresReferidos { get; set; }

        public List<Documento> Documentos { get; set; }


        public Asesor()
        {
            
        }
    }
}
