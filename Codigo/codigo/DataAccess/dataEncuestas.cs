using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webserver.Models;
using webserver.dataAccess;
using System;

namespace webserver.dataAccess{
     public class dataEncuestas : dataBase {
         public string coleccion {get;} = "Encuestas";
          public List<Encuesta> Find(){
              List<Encuesta> rdo = new List<Encuesta>(); 
               var collection = conn.db.GetCollection<Encuesta>(coleccion); 
                var options = new FindOptions {
                    MaxTime = TimeSpan.FromMilliseconds(1000)
                }; 
                 using (var cursor = collection.Find(new BsonDocument(),options).Skip(0)
                                                                                .Limit(10)
                                                                                .ToCursor()){
                 while (cursor.MoveNext()){
                     foreach (var doc in cursor.Current){ 
                          rdo.Add(doc);
                    }
                }
                cursor.Dispose();
                }
             return rdo;
          }
          
          public Encuesta FindOne(string id){
            var collection = conn.db.GetCollection<Encuesta>(coleccion); 
            var options = new FindOptions {MaxTime = TimeSpan.FromMilliseconds(1000)}; 
            var filter = new BsonDocument("_id", id);
            Encuesta e = new Encuesta(); 
            var rdo = collection.Find(filter,options).FirstOrDefault(); 
            return rdo;
          }
          public int RemoveOne(string id){
              var col = conn.db.GetCollection<Encuesta>(coleccion);
              var options = new FindOptions {MaxTime = TimeSpan.FromMilliseconds(1000)};
              var filter = new BsonDocument("_id", id);
              Encuesta e = new Encuesta();
              col.DeleteOne(a => a._id == id);
              return 1;
          }
          public int UpdateOne(Encuesta e){
            var col = conn.db.GetCollection<Encuesta>(coleccion);
            var options = new FindOptions {MaxTime = TimeSpan.FromMilliseconds(1000)};
            var filter = new BsonDocument("_id", e._id);
            var rdo = col.ReplaceOne(filter, e);
            return 1;
        }
         public Encuesta InsertOne(Encuesta e){
            var col = conn.db.GetCollection<Encuesta>(coleccion);
            col.InsertOne(e);
            return e;
            }
        }
}