using System;
using System.Data.Entity;
using FunerariaBackend.DAL.Models;

namespace FunerariaBackend.DAL.DAO
{
    public class FunerariaDbContext : DbContext
    {
        public DbSet<Estado> Estados
        {
            get;
            set;
        }

        public DbSet<Municipio> Municipios
        {
            get;
            set;
        }

        public DbSet<TipoTelefono> TiposTelefono
        {
            get;
            set;
        }

        public DbSet<Paquete> Paquetes
        {
            get;
            set;
        }

        public DbSet<Cargo> Cargos
        {
            get;
            set;
        }

        public DbSet<Documento> Documentos
        {
            get;
            set;
        }

        public FunerariaDbContext(String conStr) : base(conStr)
        {
        }
    }
}

