using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunerariaBackend.DAL.DAO
{
    class FunerariaDbContextFactory : IDbContextFactory<FunerariaDbContext>
    {
        public FunerariaDbContext Create()
        {
            return new FunerariaDbContext("name=FunerariappDbEntities");
        }
    }
}
