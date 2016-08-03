using System;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using FunerariaBackend.DAL.Models;
using CsvHelper;

namespace FunerariaBackend.DAL.FS
{
    public class EstadosCsvReader
    {
        public IEnumerable<Estado> Leer()
        {
            IEnumerable<Estado> estados = null;
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "FunerariaBackend.DAL.DbSeed.ESTADOS.CSV";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    estados = csvReader.GetRecords<Estado>().ToList();
                }
            }

            return estados;
        }
    }
}

