using System;
using System.Linq;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.DAO;

namespace FunerariaBackend.BL
{
    public class CargosRepository : IReaderRepository, IWriterRepository
    {
        FunerariaDbContext context;
        public CargosRepository(string conStr)
        {
            context = new FunerariaDbContext(conStr);
        }

        public IEnumerable<IModel> GetAll()
        {
            return (from cargos in context.Cargos
                    select cargos).ToList();
        }

        public IEnumerable<IModel> GetByFilter(IFilter modelFilter)
        {
            Cargo cargoFilter = (Cargo)modelFilter;

            var cargosFiltrados = (from cargos in context.Cargos
                                   where (cargoFilter.Id == 0 || cargos.Id == cargoFilter.Id) &&
                                   (cargoFilter.Nombre == string.Empty || cargos.Nombre.Contains(cargoFilter.Nombre))
                                   select cargos).ToList();

            return cargosFiltrados;
        }

        public IModel Insert(IModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Cargo cargoModel = (Cargo)model;
            Cargo res = context.Cargos.Add(cargoModel);
            context.SaveChanges();
            return res;
        }

        public bool Update(IModel model)
        {
            Cargo originalCargo = (from cargos in context.Cargos
                                   where cargos.Id == model.Id
                                   select cargos).Single();

            Cargo updatedCargo = (Cargo)model;
            originalCargo.Nombre = updatedCargo.Nombre;
            return context.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Cargo toDeleteCargo = (from cargos in context.Cargos
                                   where cargos.Id == id
                                   select cargos).SingleOrDefault();

            if (toDeleteCargo == null)
                return false;

            context.Cargos.Remove(toDeleteCargo);
            return context.SaveChanges() > 0;
        }
    }
}

