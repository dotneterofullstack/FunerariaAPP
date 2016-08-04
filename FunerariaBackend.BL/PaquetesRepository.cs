using System;
using System.Linq;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.DAO;

namespace FunerariaBackend.BL
{
    public class PaquetesRepository : IReaderRepository, IWriterRepositury
    {
        FunerariaDbContext context;

        public PaquetesRepository(string conStr)
        {
            context = new FunerariaDbContext(conStr);
        }

        public bool Delete(int Id)
        {
            Paquete obj = (from pqt in context.Paquetes
                           where pqt.Id == Id
                           select pqt).SingleOrDefault();

            if (obj == null)
                return false;

            context.Paquetes.Remove(obj);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<IModel> GetAll()
        {
            return (from pqt in context.Paquetes
                    select pqt).ToList();
        }

        public IEnumerable<IModel> GetByFilter(IFilter modelFilter)
        {
            Paquete pqtFilter = (Paquete)modelFilter;
            return (from pqt in context.Paquetes
                    where
                    (pqtFilter.Id == 0 || pqt.Id == pqtFilter.Id) &&
                    (pqtFilter.Descripcion == string.Empty || pqt.Descripcion.Contains(pqtFilter.Descripcion)) && 
                    (pqtFilter.Comision == 0 || pqt.Comision == pqtFilter.Comision) &&
                    (pqtFilter.Precio == 0 || pqt.Precio == pqtFilter.Precio)
                    select pqt).ToList();
        }

        public IModel Insert(IModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Paquete pqtModel = (Paquete)model;
            Paquete res = context.Paquetes.Add(pqtModel);
            context.SaveChanges();
            return res;
        }

        public bool Update(IModel model)
        {
            Paquete updatedPaquete = (Paquete)model;

            var originalPaquete = (from p in context.Paquetes
                       where p.Id == updatedPaquete.Id
                       select p).Single();

            originalPaquete.Descripcion = updatedPaquete.Descripcion;
            originalPaquete.Precio = updatedPaquete.Precio;
            originalPaquete.Comision = updatedPaquete.Comision;
            originalPaquete.SoloCremacion = updatedPaquete.SoloCremacion;
            context.SaveChanges();

            return true;
        }
    }
}

