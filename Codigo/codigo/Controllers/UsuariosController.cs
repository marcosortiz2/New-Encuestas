using Microsoft.AspNetCore.Mvc;
using webserver.Models;
namespace webserver.Controllers{
[Route("api/usuarios")]
    public class UsuariosController : Controller {
        [HttpGet]
        public Usuario[] Get(){
            return userRepository.GetUsuarios();
        }
        [HttpGet("{id}")]
            public Usuario Get(string id){
            return userRepository.GetUsuarioById(id);
    }
        [HttpPost]
        public ActionResult Post([FromBody]Usuario u){
            userRepository.AddUsuario(u);
            return Redirect("http://localhost/index.html");
        }
        [HttpPut]
        public void Put([FromBody]Usuario u){
            userRepository.UpdateUsuarioById(u);
        }
        [HttpDelete("{id}")]
        public void Delete(string id){
            userRepository.RemoveUsuarioById(id);
        }
    }
}

[Route("api/login")]
    public class UsuariosController : Controller{
        [HttpPost]
        public ActionResult Post([FromBody]Usuario u){
            if(userRepository.login(u.username,u.password)){
                return Redirect("http://localhost/encuestas.html");
            }
            return Redirect("http://localhost/index.html");
        }
    }