using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaBackend.DAL.Models
{
    [Table("Paquetes")]
    public class Paquete : IModel, IFilter
    {
        public int Id
        {
            get;
            set;
        }

        [Required]
        [MaxLength(200)]
        public string Descripcion
        {
            get;
            set;
        }

        [Required]
        public decimal Precio
        {
            get;
            set;
        }

        [Required]
        public decimal Comision
        {
            get;
            set;
        }

        [Required]
        public bool SoloCremacion
        {
            get;
            set;
        }

        public Paquete()
        {
            Id = 0;
            Descripcion = string.Empty;
            Precio = 0.0m;
            Comision = 0.0m;
            SoloCremacion = false;
        }

        public bool EstaVacio()
        {
            return Id == 0 &&
                Descripcion == string.Empty &&
                Precio == 0.0m &&
                Comision == 0.0m &&
                SoloCremacion == false;
        }
    }
}

