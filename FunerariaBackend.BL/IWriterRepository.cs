using System;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;

namespace FunerariaBackend.BL
{
    public interface IWriterRepository
    {
        bool Update(IModel model);
        bool Delete(int id);
        IModel Insert(IModel model);
    }
}

