using System;
using System.Collections.Generic;
using System.Web.Http;
using FunerariaBackend.BL;
using FunerariaBackend.DAL.Models;

namespace FunerariaBackend.API.Controllers
{
    public class EstadosController : ApiController
    {
        EstadosRepository repo;
        public EstadosController()
        {
            repo = new EstadosRepository("name=FunerariappDbEntities");
        }

        public IEnumerable<IModel> Get()
        {
            return repo.GetAll();
        }
    }
}

