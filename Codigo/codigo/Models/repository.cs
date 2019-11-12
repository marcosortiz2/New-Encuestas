using System.Collections.Generic;
using System;
using webserver.dataAccess;
using webserver.Models; 

namespace webserver.Models{
    public class userRepository{
        public static IList<Usuario> Usuarios{get;} = new List<Usuario>();
        private static string counter="0";
        public static Usuario[] GetUsuarios(){
            dataUsuarios u = new dataUsuarios();
            var rdo = u.Find();
            return rdo.ToArray();
        }

        public static Usuario GetUsuarioById(string _id){
            dataUsuarios u = new dataUsuarios();
            return u.FindOne(_id);
        }
        public static Usuario GetUsuarioByName(string username){
            dataUsuarios u = new dataUsuarios();
            return u.FindOne(username);
        }
        public static void RemoveUsuarioById(string _id){
            dataUsuarios u = new dataUsuarios();
            u.RemoveOne(_id);
        }
        public static void UpdateUsuarioById(Usuario u){
            dataUsuarios us = new dataUsuarios();
            us.UpdateOne(u);
        }
        public static void AddUsuario(Usuario u){
            int cont = Int32.Parse(counter) + 1;
            counter = cont.ToString();
            u._id = counter;
            dataUsuarios us = new dataUsuarios();
            us.InsertOne(u);
        }   
         public static bool login(string username,string password){
             dataUsuarios u = new dataUsuarios();
             return(u.login(username, password));
         }
    }
    public class pollRepository{
        public static IList<Encuesta> Usuarios{get;} = new List<Encuesta>();
        private static string counter="0";
        public static Encuesta[] GetEncuestas(){
            dataEncuestas e = new dataEncuestas();
            var rdo = e.Find();
            return rdo.ToArray();
        }

        public static Encuesta GetEncuestaById(string _id){
            dataEncuestas e = new dataEncuestas();
            return e.FindOne(_id);
        }
        public static void RemoveEncuestaById(string _id){
            dataEncuestas e = new dataEncuestas();
            e.RemoveOne(_id);
        }
        public static void UpdateEncuestaById(Encuesta e){
            dataEncuestas en = new dataEncuestas();
            en.UpdateOne(e);
        }
        public static void AddEncuesta(Encuesta e){
            int cont = Int32.Parse(counter) + 1;
            counter = cont.ToString();
            e._id = counter;
            dataEncuestas en = new dataEncuestas();
            en.InsertOne(e);
        }
    }
}