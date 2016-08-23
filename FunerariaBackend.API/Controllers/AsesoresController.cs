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
    public class AsesoresController : ApiController
    {
        AsesoresRepository repo;
        public AsesoresController()
        {
            repo = new AsesoresRepository("name=FunerariappDbEntities");
        }

        public IEnumerable<IModel> Get([FromUri]Asesor cargo = null)
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

        public IModel Post(Asesor asesor)
        {
            return repo.Insert(asesor);
        }

        public IEnumerable<IModel> Put(Asesor asesor)
        {
            if (repo.Update(asesor))
                return repo.GetAll();
            return null;
        }

        public bool Delete(int id)
        {
            return repo.Delete(id);
        }
    }
}
