using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FunerariaBackend.DAL.Models;
using FunerariaBackend.BL;

namespace FunerariaBackend.API.Controllers
{
    public class MunicipiosController : ApiController
    {
        MunicipiosRepository repo;
        public MunicipiosController()
        {
            repo = new MunicipiosRepository("name=FunerariappDbEntities");
        }

        public IEnumerable<IModel> Get([FromUri]Municipio municipio = null)
        {
            if (municipio.EstaVacio())
            {
                return repo.GetAll();
            }
            else
            {
                return repo.GetByFilter(municipio);
            }
        }
    }
}
