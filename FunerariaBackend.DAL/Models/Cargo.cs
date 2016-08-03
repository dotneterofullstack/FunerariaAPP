﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunerariaBackend.DAL.Models
{
    [Table("Cargos")]
    public class Cargo : IModel
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
    }
}
