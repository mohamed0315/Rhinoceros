using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Rhinoceros.Reader.Repositories
{
    public class DepartementRepository
    {
        public DepartementRepository()
        {
        }


        public static List <Departement> GetDepartements()
        {
            List<Departement> departements = new List<Departement>();

            MongoClient dbClient = new MongoClient("mongodb+srv://mabouyaaqoub:LlWmTsJcRgzMo1qk@cluster0.wo8wi.mongodb.net/rhinoceros?retryWrites=true&w=majority");

            var dbList = dbClient.ListDatabases().ToList();

            var database = dbClient.GetDatabase("rhinoceros");
            //var collection = database.GetCollection<BsonDocument>("departments");
            IMongoCollection<Departement> collection = database.GetCollection<Departement>("departements");

            return departements;
        }
    }
}
