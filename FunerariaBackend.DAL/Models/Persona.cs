using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace FunerariaBackend.DAL.Models
{
    public abstract class Persona: IModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings =false)]
        [MaxLength(100)]
        public string Nombre { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string ApellidoPaterno { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(100)]
        public string ApellidoMaterno { get; set; }

        [MaxLength(13)]
        public string RFC { get; set; }

        public List<Telefono> Telefonos { get; set; }
        public List<Domicilio> Domicilios { get; set; }
}
}
