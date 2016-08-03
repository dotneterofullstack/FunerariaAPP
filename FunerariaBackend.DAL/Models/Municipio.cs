using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaBackend.DAL.Models
{
    [Table("Municipios")]
    public class Municipio : IModel, IFilter
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [MaxLength(100)]
        public string Nombre
        {
            get;
            set;
        }

        [Required]
        public int IdEstado
        {
            get;
            set;
        }

        [ForeignKey("IdEstado")]
        public Estado Estado
        {
            get;
            set;
        }

        public Municipio()
        {
            Id = 0;
            Nombre = String.Empty;
            IdEstado = 0;
        }

        public bool EstaVacio()
        {
            return Id == 0 &&
                Nombre == String.Empty &&
                IdEstado == 0;
        }
    }
}

