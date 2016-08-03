using System;
using System.Linq;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.DAO;

namespace FunerariaBackend.BL
{
    public class TiposTelefonoRepository : IReaderRepository
    { 
        FunerariaDbContext context;

        public TiposTelefonoRepository(string conStr)
        {
            context = new FunerariaDbContext(conStr);
        }

        public IEnumerable<IModel> GetAll()
        {
            return (from tpos in context.TiposTelefono
                   select tpos).ToList();
        }

        public IEnumerable<IModel> GetByFilter(IFilter modelFilter)
        {
            TipoTelefono tipoLilter = (TipoTelefono)modelFilter;
            return (from tpos in context.TiposTelefono
                    where
                    (tipoLilter.Id == 0 || tpos.Id == tipoLilter.Id) &&
                    (tipoLilter.Nombre == string.Empty || tpos.Nombre.Contains(tipoLilter.Nombre))
                    select tpos).ToList();
        }
    }
}

