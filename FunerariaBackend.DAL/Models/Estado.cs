using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaBackend.DAL.Models
{
    [Table("Estados")]
    public class Estado : IModel, IFilter
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [MaxLength(50)]
        public string Nombre
        {
            get;
            set;
        }

        [Required]
        [MaxLength(10)]
        public string Abreviatura
        {
            get;
            set;
        }

        public List<Municipio> Municipios
        {
            get;
            set;
        }

        public Estado()
        {
            Id = 0;
            Nombre = string.Empty;
            Abreviatura = string.Empty;
        }

        public bool EstaVacio()
        {
            return Id == 0 &&
                Nombre == string.Empty &&
                Abreviatura == string.Empty;
        }
    }
}

