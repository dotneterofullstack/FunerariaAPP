using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaBackend.DAL.Models
{
    [Table("TiposTelefono")]
    public class TipoTelefono : IModel, IFilter
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [MaxLength(15)]
        public string Nombre
        {
            get;
            set;
        }

        public TipoTelefono()
        {
            Id = 0;
            Nombre = string.Empty;
        }

        public bool EstaVacio()
        {
            return Id == 0 &&
                Nombre == string.Empty;
        }
    }
}

