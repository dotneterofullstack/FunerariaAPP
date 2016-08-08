using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaBackend.DAL.Models
{
    [Table("Documentos")]
    public class Documento : IModel
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

        public List<Asesor> Asesors { get; set; }
    }
}

