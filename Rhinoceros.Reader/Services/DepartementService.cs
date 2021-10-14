using System;
using System.Collections.Generic;
using MongoDB.Driver;
using Rhinoceros.Reader.Repositories;
using System.Linq;


namespace Rhinoceros.Reader.Services
{
    public class DepartementService
    {
        public DepartementService()
        {
        }

        public static IEnumerable<Departement> GetDeptByParams(string code, string name)
        {
            Departement departement = new Departement();

            MongoClient dbClient = new MongoClient("mongodb+srv://mabouyaaqoub:LlWmTsJcRgzMo1qk@cluster0.wo8wi.mongodb.net/rhinoceros?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("rhinoceros");
            IMongoCollection<Departement> collection = database.GetCollection<Departement>("departements");

            IEnumerable<Departement> query = from e in collection.AsQueryable()
                                             select e;

            if (!(code.Length >= 3) && !(code is null))
            {
                query = from e in query
                        where e.code.StartsWith(name)
                        select e;

            }

            if (!(name.Length >= 3) && !(name is null))
            {
                query = from e in query
                        where e.name.StartsWith(name)
                        select e;

            }

            if (!query.Any())
            {
                return null;
            }

            return query;
        }

        public static System.Collections.Generic.IEnumerable<Departement> GetAll()
        {
            List<Departement> departements = new List<Departement>();

            MongoClient dbClient = new MongoClient("mongodb+srv://mabouyaaqoub:LlWmTsJcRgzMo1qk@cluster0.wo8wi.mongodb.net/rhinoceros?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("rhinoceros");
            IMongoCollection<Departement> collection = database.GetCollection<Departement>("departements");

            IEnumerable<Departement> query = from e in collection.AsQueryable()
                                             select e;

            return query;
        }

        public static IEnumerable<Departement> GetDeptByName(string name)
        {
            Departement departement = new Departement();

            MongoClient dbClient = new MongoClient("mongodb+srv://mabouyaaqoub:LlWmTsJcRgzMo1qk@cluster0.wo8wi.mongodb.net/rhinoceros?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("rhinoceros");
            IMongoCollection<Departement> collection = database.GetCollection<Departement>("departements");

            IEnumerable<Departement> query = from e in collection.AsQueryable()
                                             select e;

            if (!(name.Length >= 3) && !(name is null))
            {
                query = from e in query
                        where e.name.StartsWith(name)
                        select e;

            }

            if (!query.Any())
            {
                return null;
            }

            return query;
        }

        public static IEnumerable<Departement> GetDeptByCode(string code)
        {
            Departement departement = new Departement();

            MongoClient dbClient = new MongoClient("mongodb+srv://mabouyaaqoub:LlWmTsJcRgzMo1qk@cluster0.wo8wi.mongodb.net/rhinoceros?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("rhinoceros");
            IMongoCollection<Departement> collection = database.GetCollection<Departement>("departements");

            IEnumerable<Departement> query = from e in collection.AsQueryable()
                                             select e;

            if (!(code.Length >= 3) && !(code is null))
            {
                query = from e in query
                        where e.code.StartsWith(code)
                        select e;

            }

            if (!query.Any())
            {
                return null;
            }

            return query;
        }
    }
}
