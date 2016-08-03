using System;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using FunerariaBackend.DAL.Models;
using CsvHelper;
using System.Text;

namespace FunerariaBackend.DAL.FS
{
    public class TiposTelefonoCsvReader
    {
        public IEnumerable<TipoTelefono> Leer()
        {
            IEnumerable<TipoTelefono> tipos = null;
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "FunerariaBackend.DAL.DbSeed.TIPOS_TELEFONO.CSV";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    tipos = csvReader.GetRecords<TipoTelefono>().ToList();
                }
            }

            return tipos;
        }
    }
}

