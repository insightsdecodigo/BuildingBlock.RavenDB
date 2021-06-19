using Microsoft.Extensions.Configuration;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Session;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace BuildingBlock.RavenDB.Services
{
    public class RavenDataBase : IRavenDataBase
    {
        private readonly string collectionName;
        private readonly IDocumentStore DBRavenClient;
        public RavenDataBase(IConfiguration configuration)
        {
            collectionName = configuration["RAVENDB_COLLECTIONNAME"];
            DBRavenClient = new DocumentStore()
            {
                // Define the cluster node URLs (required)
                Urls = new[] { configuration["RAVENDB_CONFIGURATION_URL"],
                               /*some additional nodes of this cluster*/ },

                // Set conventions as necessary (optional)
                Conventions =
                {
                    MaxNumberOfRequestsPerSession = int.Parse(configuration["RAVENDB_MAX_NUMBER_OF_REQUESTS_PER_SESSION"]),
                    UseOptimisticConcurrency = bool.Parse(configuration["RAVENDB_OPTIMISTIC_CONCURRENCY"]),
                    FindCollectionName = type =>
                    {
                        return DocumentConventions.DefaultGetCollectionName(type);
                    }
                },

                // Define a default database (optional)
                Database = configuration["RAVENDB_INSTANCE_NAME"],

                // Define a client certificate (optional)
                Certificate = new X509Certificate2(
                         configuration?["RAVENDB_PATH_CERTIFICATE"]
                         ),

                // Initialize the Document Store
            }.Initialize();
        }

        public void Create(object obj)
        {
            using IDocumentSession session = DBRavenClient.OpenSession();
            session.Store(obj);
            session.Advanced.GetMetadataFor(obj)[Constants.Documents.Metadata.Collection] = collectionName;
            session.SaveChanges();
        }

        public void Update<T>(string objID, T obj) where T : class, new()
        {
            using IDocumentSession session = DBRavenClient.OpenSession();
            var objBase = session.Load<T>(objID);
            objBase = obj;
            session.SaveChanges();
        }

        public void Delete(string objID)
        {
            using IDocumentSession session = DBRavenClient.OpenSession();
            session.Delete(objID);
            session.SaveChanges();
        }

        public T LoadSingleEntry<T>(string objID) where T : class, new()
        {
            using IDocumentSession session = DBRavenClient.OpenSession();
            var entry = session.Load<T>(objID);

            return entry;
        }

        public List<T> LoadQuerying<T>(string Name) where T : class, new()
        {
            using IDocumentSession session = DBRavenClient.OpenSession();
            List<T> results = session
             .Query<T>(collectionName: Name)
             .ToList();

            return results;
        }
    }
}
