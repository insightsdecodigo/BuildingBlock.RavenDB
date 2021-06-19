using BuildingBlock.RavenDB.Services;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace PocRavenDB
{
    class Objeto
    {
        public string Name;
        public string LastUpdate;
    }
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Carregando configurações...");
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();


            Console.WriteLine("Configurações carregadas com sucesso...");
            Console.WriteLine();

            Console.WriteLine($"Url: {configuration?["RAVENDB_CONFIGURATION_URL"]}");
            Console.WriteLine($"DataBase: {configuration?["RAVENDB_INSTANCE_NAME"]}");
            Console.WriteLine($"Tabela: {configuration?["RAVENDB_COLLECTIONNAME"]}");
            Console.WriteLine($"...");
            Console.WriteLine($"Rate limit: {configuration?["RAVENDB_MAX_NUMBER_OF_REQUESTS_PER_SESSION"]}");
            Console.WriteLine($"Concorrencia: {configuration?["RAVENDB_OPTIMISTIC_CONCURRENCY"]}");
            Console.WriteLine($"Certificado: {configuration?["RAVENDB_PATH_CERTIFICATE"]}");
                        Console.WriteLine($"...");

            RavenDataBase dao = new RavenDataBase(configuration);

            // insert bunches of data efficiently
            //for (int i = 0; i < 10; i++)
            //{
            //    dao.Create(new Objeto
            //    {
            //        LastUpdate = DateTime.UtcNow.ToString(),
            //        Name = "SampleObjeto" + i.ToString()
            //    });
            //}

            //dao.Update("SampleObjeto0", new Objeto
            //{
            //    LastUpdate = DateTime.UtcNow.ToString(),
            //    Name = "SampleObjetoAlterado1"
            //});


            //dao.Delete("SampleObjeto0");
            //var obj = dao.LoadSingleEntry<Objeto>("objetos/2-A");
            //Console.WriteLine(obj.Name);

            var list = dao.LoadQuerying<Objeto>("Objeto");
            foreach(var obj in list)
                Console.WriteLine($"Name: {obj.Name} - Date: {obj.LastUpdate}");

            Console.ReadLine();
        }
    }
}
