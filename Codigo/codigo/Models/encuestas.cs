namespace webserver.Models{
    public class Encuesta {
        public string _id {get; set;}
        public string title{get; set;}
        public bool type{get; set;} // 0 = elección simple, 1 = elección múltiple
        public bool state{get; set;} // 0 = desactivada, 1 = activda
        public string language{get; set;}
        public bool repeat{get; set;}
        public Opcion[] choices {get; set;}
    }
}