namespace webserver.Models{
    public class Opcion {
        public string _id {get;set;}
        public string name{get; set;}
        public Voto[] votes{get;set;}
    }
}