using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FunerariaBackend.BL;
using FunerariaBackend.DAL.Models;

namespace FunerariaBackend.API.Controllers
{
    public class DocumentosController : ApiController
    {
        DocumentosRepository repo;

        public DocumentosController()
        {
            repo = new DocumentosRepository("name=FunerariappDbEntities");
        }

        public IEnumerable<IModel> Get([FromUri]Documento documento = null)
        {
            if (documento.EstaVacio())
            {
                return repo.GetAll();
            }
            else
            {
                return repo.GetByFilter(documento);
            }
        }
    }
}
