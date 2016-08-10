using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.DAO;

namespace FunerariaBackend.BL
{
    public class AsesoresRepository : IReaderRepository, IWriterRepository
    {
        FunerariaDbContext context;
        public AsesoresRepository(String conStr)
        {
            context = new FunerariaDbContext(conStr);
        }

        public bool Delete(int id)
        {
            Asesor asesorPorBorrar = (from asesores in context.Asesores
                                    where asesores.Id == id
                                    select asesores).SingleOrDefault();

            if (asesorPorBorrar == null)
                return false;
            context.Asesores.Remove(asesorPorBorrar);
            return context.SaveChanges() > 0;
        }

        public IEnumerable<IModel> GetAll()
        {
            return (from asesores in context.Asesores
                    select asesores).ToList();
        }

        public IEnumerable<IModel> GetByFilter(IFilter modelFilter)
        {
            Asesor asesorFilter = (Asesor)modelFilter;

            return (from asesores in context.Asesores
                    where 
                    (asesorFilter.Id == 0 || asesores.Id == asesorFilter.Id) &&
                    (asesorFilter.Nombre == String.Empty || asesores.Nombre.Contains(asesorFilter.Nombre)) &&
                    (asesorFilter.ApellidoPaterno == String.Empty || asesores.ApellidoPaterno.Contains(asesorFilter.ApellidoPaterno)) &&
                    (asesorFilter.ApellidoMaterno == String.Empty || asesores.ApellidoMaterno.Contains(asesorFilter.ApellidoMaterno)) &&
                    (asesorFilter.RFC == String.Empty || asesores.RFC.Contains(asesorFilter.RFC)) &&
                    (asesorFilter.IdCargo == 0 || asesores.IdCargo == asesorFilter.IdCargo) &&
                    (asesorFilter.IdReferidoPor == null || asesores.IdReferidoPor == asesorFilter.IdReferidoPor) &&
                    (asesorFilter.Codigo == String.Empty || asesores.Codigo.Contains(asesorFilter.Codigo))
                    select asesores).ToList();
            
        }

        public IModel Insert(IModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Asesor asesor = (Asesor)model;
            Asesor nuevoAsesor = context.Asesores.Add(asesor);
            context.SaveChanges();
            return nuevoAsesor;
        }

        public bool Update(IModel model)
        {
            Asesor asesorOriginal = (from asesores in context.Asesores
                                     where asesores.Id == model.Id
                                     select asesores).Single();

            Asesor asesorActualizado = (Asesor)model;
            asesorOriginal.ApellidoMaterno = asesorActualizado.ApellidoMaterno;
            asesorOriginal.ApellidoPaterno = asesorActualizado.ApellidoPaterno;
            asesorOriginal.Codigo = asesorActualizado.Codigo;
            asesorOriginal.IdCargo = asesorActualizado.IdCargo;
            asesorOriginal.IdReferidoPor = asesorActualizado.IdReferidoPor;
            asesorOriginal.Nombre = asesorActualizado.Nombre;
            asesorOriginal.RFC = asesorActualizado.RFC;
            return context.SaveChanges() > 0;
        }
    }
}
