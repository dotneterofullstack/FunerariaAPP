using System;
using System.Collections.Generic;
using System.Web.Http;
using FunerariaBackend.BL;
using FunerariaBackend.DAL.Models;

namespace FunerariaBackend.API.Controllers
{
    public class PaquetesController : ApiController
    {
        PaquetesRepository repo;
        public PaquetesController()
        {
            repo = new PaquetesRepository("name=FunerariappDbEntities");
        }

        public IEnumerable<IModel> Get([FromUri]Paquete paquete = null)
        {
            if (paquete.EstaVacio())
            {
                return repo.GetAll();
            }
            else
            {
                return repo.GetByFilter(paquete);
            }
        }

        public IModel Post(Paquete paquete)
        {
            return repo.Insert(paquete);
        }

        public IEnumerable<IModel> Put(Paquete paquete)
        {
            if (repo.Update(paquete))
                return repo.GetAll();
            return null;
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}

