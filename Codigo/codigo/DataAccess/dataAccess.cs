using MongoDB.Bson;
using MongoDB.Driver;

namespace webserver.dataAccess{
    public class dataBase{
        public conection conn = new conection();
    }
    public class conection {
        public IMongoDatabase db;
        public MongoClient client{get;set;}
        public conection(){
            client = new MongoClient("mongodb://localhost:27017/encuestas");
            db = client.GetDatabase("encuestas");
        }
    }
}