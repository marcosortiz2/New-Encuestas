using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using webserver.Models;
using webserver.dataAccess;
using System;

namespace webserver.dataAccess{
     public class dataUsuarios : dataBase {
         public string coleccion {get;} = "usuarios";
          public List<Usuario> Find(){
              List<Usuario> rdo = new List<Usuario>(); 
               var collection = conn.db.GetCollection<Usuario>(coleccion); 
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
          
          public Usuario FindOne(string id){
            var collection = conn.db.GetCollection<Usuario>(coleccion); 
            var options = new FindOptions {MaxTime = TimeSpan.FromMilliseconds(1000)}; 
            var filter = new BsonDocument("_id", id);
            Usuario u = new Usuario(); 
            var rdo = collection.Find(filter,options).FirstOrDefault(); 
            return rdo;
          }
            public bool login(string username, string password){
            var collection = conn.db.GetCollection<Usuario>(coleccion); 
            var options = new FindOptions {MaxTime = TimeSpan.FromMilliseconds(1000)}; 
            var filter = new BsonDocument("username", username);
            Usuario u = new Usuario(); 
            var rdo = collection.Find(filter,options).FirstOrDefault();
            if(rdo.password.Equals(password)){
                return true;
            } 
            return false;
          }
          public int RemoveOne(string id){
              var col = conn.db.GetCollection<Usuario>(coleccion);
              var options = new FindOptions {MaxTime = TimeSpan.FromMilliseconds(1000)};
              var filter = new BsonDocument("_id", id);
              Usuario u = new Usuario();
              col.DeleteOne(a => a._id == id);
              return 1;
          }
          public int UpdateOne(Usuario u){
            var col = conn.db.GetCollection<Usuario>(coleccion);
            var options = new FindOptions {MaxTime = TimeSpan.FromMilliseconds(1000)};
            var filter = new BsonDocument("_id", u._id);
            var rdo = col.ReplaceOne(filter, u);
            return 1;
        }
         public Usuario InsertOne(Usuario u){
            var col = conn.db.GetCollection<Usuario>(coleccion);
            col.InsertOne(u);
            return u;
            }
        }
}