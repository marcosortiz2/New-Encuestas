using Microsoft.AspNetCore.Mvc;
using webserver.Models;

namespace webserver.Controllers{

[Route("api/encuestas")]
    public class EncuestasController : Controller {
        [HttpGet]
        public Encuesta[] Get(){
            return pollRepository.GetEncuestas();
        }
        [HttpGet("{id}")]
            public Encuesta Get(string id){
            return pollRepository.GetEncuestaById(id);
    }
        [HttpPost]
        public void Post([FromBody]Encuesta e){
            pollRepository.AddEncuesta(e);
        }
        [HttpPut]
        public void Put([FromBody]Encuesta e){
            pollRepository.UpdateEncuestaById(e);
        }
        [HttpDelete("{id}")]
        public void Delete(string id){
            pollRepository.RemoveEncuestaById(id);
        }
    }
}