using System;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;

namespace FunerariaBackend.BL
{
    public interface IReaderRepository
    {
        IEnumerable<IModel> GetAll();
        IEnumerable<IModel> GetByFilter(IFilter modelFilter);
    }
}

