using System;
using System.Linq;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.DAO;

namespace FunerariaBackend.BL
{
    public class EstadosRepository : IReaderRepository
    {
        FunerariaDbContext context;

        public EstadosRepository(string conStr)
        {
            context = new FunerariaDbContext(conStr); 
        }

        public IEnumerable<IModel> GetAll()
        {
            return (from edos in context.Estados
                    select edos).ToList();
        }

        public IEnumerable<IModel> GetByFilter(IFilter modelFilter)
        {
            Estado edoFilter = (Estado)modelFilter;
            return (from edos in context.Estados
                    where
                        (edoFilter.Id == 0 || edos.Id == edoFilter.Id) &&
                        (edoFilter.Nombre == string.Empty || edos.Nombre.Contains(edoFilter.Nombre)) &&
                        (edoFilter.Abreviatura == string.Empty || edos.Abreviatura.Contains(edoFilter.Abreviatura))
                    select edos).ToList();
        }
    }
}

