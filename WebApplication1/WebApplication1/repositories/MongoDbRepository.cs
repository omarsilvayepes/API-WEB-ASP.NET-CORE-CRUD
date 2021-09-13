using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.repositories
{
    public class MongoDbRepository

    {
        public static string MONGO_URI = "mongodb+srv://admin:mongoDB@proyectos.v5ovr.mongodb.net/inventario_Csharp?retryWrites=true&w=majority";
        public static string MONGO_DB = "inventario_Csharp";
        public MongoClient client;
        public IMongoDatabase db;

        public MongoDbRepository()
        {
            var settings = MongoClientSettings.FromConnectionString(MONGO_URI);
            client = new MongoClient(settings);
            db = client.GetDatabase(MONGO_DB);

        }
    }
}
