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
    public class DocumentosCsvReader
    {
        public IEnumerable<Documento> Leer()
        {
            IEnumerable<Documento> documentos = null;
            Assembly assembly = Assembly.GetExecutingAssembly();

            string resourceName = "FunerariaBackend.DAL.DbSeed.DOCUMENTOS.CSV";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                {
                    CsvReader csvReader = new CsvReader(reader);
                    csvReader.Configuration.WillThrowOnMissingField = false;
                    documentos = csvReader.GetRecords<Documento>().ToList();
                }
            }

            return documentos;
        }
    }
}

