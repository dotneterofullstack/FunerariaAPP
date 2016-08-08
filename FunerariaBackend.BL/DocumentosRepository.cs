using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.DAL.DAO;

namespace FunerariaBackend.BL
{
    public class DocumentosRepository : IReaderRepository
    {
        FunerariaDbContext context;

        public DocumentosRepository(String conStr)
        {
            context = new FunerariaDbContext(conStr);
        }
        public IEnumerable<IModel> GetAll()
        {
            return (from documentos in context.Documentos
                    select documentos).ToList();
        }

        public IEnumerable<IModel> GetByFilter(IFilter modelFilter)
        {
            Documento docFilter = (Documento)modelFilter;

            return (from documentos in context.Documentos
                    where (docFilter.Id == 0 || documentos.Id == docFilter.Id) &&
                    (docFilter.Nombre == string.Empty || documentos.Nombre.Contains(docFilter.Nombre))
                    select documentos).ToList();
        }
    }
}
