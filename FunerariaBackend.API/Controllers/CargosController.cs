using FunerariaBackend.BL;
using FunerariaBackend.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FunerariaBackend.API.Controllers
{
    public class CargosController : ApiController
    {
        CargosRepository repo;

        public CargosController()
        {
            repo = new CargosRepository("name=FunerariappDbEntities");
        }
        // GET: api/Cargos
        public IEnumerable<IModel> Get([FromUri]Cargo cargo = null)
        {
            if (cargo.EstaVacio())
            {
                return repo.GetAll();
            }
            else
            {
                return repo.GetByFilter(cargo);
            }
        }

        // POST: api/Cargos
        public IModel Post(Cargo cargo)
        {
            return repo.Insert(cargo);
        }

        // PUT: api/Cargos/5
        public IEnumerable<IModel> Put(Cargo cargo)
        {
            if (repo.Update(cargo))
                return repo.GetAll();
            return null;
        }

        // DELETE: api/Cargos/5
        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
