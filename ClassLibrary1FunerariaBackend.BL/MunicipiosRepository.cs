using System;
using System.Linq;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.DAO;

namespace FunerariaBackend.BL
{
    public class MunicipiosRepository : IReaderRepository
    {
        FunerariaDbContext context;

        public MunicipiosRepository(string conStr)
        {
            context = new FunerariaDbContext(conStr);
        }

        public IEnumerable<IModel> GetAll()
        {
            return (from muns in context.Municipios
                   select muns).ToList();
        }

        public IEnumerable<IModel> GetByFilter(IFilter modelFilter)
        {
            Municipio munFilter = (Municipio)modelFilter;
            return (from muns in context.Municipios
                    where
                    (munFilter.Id == 0 || muns.Id == munFilter.Id) &&
                    (munFilter.IdEstado == 0 || muns.IdEstado == munFilter.IdEstado) &&
                    (munFilter.Nombre == string.Empty || muns.Nombre.Contains(munFilter.Nombre))
                    select muns).ToList();
        }
    }
}

