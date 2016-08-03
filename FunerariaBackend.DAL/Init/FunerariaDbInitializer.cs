using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using FunerariaBackend.DAL.DAO;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.FS;

namespace FunerariaBackend.DAL.Init
{
    public class FunerariaDbInitializer : CreateDatabaseIfNotExists<FunerariaDbContext>
    {
        protected override void Seed(FunerariaDbContext context)
        {
            EstadosCsvReader edosreader = new EstadosCsvReader();
            MunicipiosCsvReader mposReader = new MunicipiosCsvReader();
            TiposTelefonoCsvReader tiposTelReader = new TiposTelefonoCsvReader();
            //PaquetesCsvReader paquetesReader = new PaquetesCsvReader();

            DocumentosCsvReader documentosReader = new DocumentosCsvReader();

            IEnumerable<Estado> estados = edosreader.Leer();
            IEnumerable<Municipio> municipios = mposReader.Leer();
            IEnumerable<TipoTelefono> tiposTelefono = tiposTelReader.Leer();
            //IEnumerable<Paquete> paquetes = paquetesReader.Leer();

            IEnumerable<Documento> documentos = documentosReader.Leer();

            context.Estados.AddOrUpdate(e => e.Id, estados.ToArray());
            foreach (var mun in municipios)
            {
                int idEstado = mun.IdEstado;
                mun.Estado = context.Estados.Local.Single(e => e.Id == idEstado);
                context.Municipios.AddOrUpdate(m => m.Id, mun);
            }
            context.TiposTelefono.AddOrUpdate(t => t.Id, tiposTelefono.ToArray());
            //context.Paquetes.AddOrUpdate(p => p.Id, paquetes.ToArray());
            context.Documentos.AddOrUpdate(d => d.Id, documentos.ToArray());

            context.SaveChanges();
        }
    }
}

