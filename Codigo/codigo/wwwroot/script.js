var url = "http://localhost:5000/api/Usuarios/";

function mostrar(datos,lugar){

let d = document.getElementById(lugar);

let tabla = "<table border=1>";

let aux = [];

if(Array.isArray(datos)){

Object.assign(aux, datos);

} else {

aux.push(datos);

}

tabla = aux.reduce((acum, elem)=>{

return acum +

"<tr>" +

"<td><button onclick='eliminarUsuario(" + elem._id + ");'_>X</button></td>" +

"<td>" + elem._id + "</td>" +

"<td>" + elem.username + "</td>" +

"<td>" + elem.password + "</td>" +

"<td>" + elem.email + "</td>" +

"</tr>";

},tabla)

tabla += "</table>";

d.innerHTML = tabla;

}

function traerUsuarios(){  let misCabeceras = new Headers();

    let miInit = { method: 'GET',
    
    headers: misCabeceras,
    
    mode: 'cors',
    
    cache: 'default' };
    
    let agregar="";
    
    
    if(id){
    
    console.log("id:", id);
    
    agregar += id;
    
    } else {
    
    console.log("no tienen nada el id")
    
    }
    
    console.log("buscando: ", url + agregar);
    
    fetch(url + agregar,miInit)
    
    .then(function(response) {
    
    console.log(response);
    
    if (response.status == 200){
    
    return response.json();
    
    }
    
    return {"mensaje": response.statusText};
    
    })
    
    .then(function(rta) {
    
    console.log(rta);
    
    mostrar(rta,"resultados");
    
    });
    
    }
    function traerUsuarios(){  let misCabeceras = new Headers();

    let miInit = { method: 'GET',
    
    headers: misCabeceras,
    
    mode: 'cors',
    
    cache: 'default' };
    
    let agregar="";
    
    
    if(id){
    
    console.log("id:", id);
    
    agregar += id;
    
    } else {
    
    console.log("no tienen nada el id")
    
    }
    
    console.log("buscando: ", url + agregar);
    
    fetch(url + agregar,miInit)
    
    .then(function(response) {
    
    console.log(response);
    
    if (response.status == 200){
    
    return response.json();
    
    }
    
    return {"mensaje": response.statusText};
    
    })
    
    .then(function(rta) {
    
    console.log(rta);
    
    mostrar(rta,"resultados");
    
    });
    
    }
    function agregarUsuario(){
    
    let username = document.getElementById("username").value;
    
    let password = document.getElementById("password").value;

    let email = document.getElementById("email").value;
    
    let Usuario = {};
    
    Usuario.username = username;
    
    Usuario.password = password;

    Usuario.email = email;
    
    Usuario._id = null;  fetch(url, {

method: 'POST', // or 'PUT'

body: JSON.stringify(Usuario), // data can be `string` or {object}!

headers:{

'Content-Type': 'application/json'

}

}

)

.then(function(res){

console.log(res);

return res;

})

.catch(function(error){

console.log(error);

})

.then(function (response) {

console.log("success: ", response);


});

}

function eliminarUsuario(id){

fetch(url + id, {

method: 'DELETE', // or 'PUT'

headers:{

'Content-Type': 'application/json'

}

}

)

.then(function(res){

console.log(res);

return res;

})

.catch(function(error){

console.log(error);

})

.then(function (response) {

console.log("success: ", response);


});
fetch(url, {

    method: 'POST', // or 'PUT'
    
    body: JSON.stringify(Usuario), // data can be `string` or {object}!
    
    headers:{
    
    'Content-Type': 'application/json'
    
    }
    
    }
    
    )
    
    .then(function(res){
    
    console.log(res);
    
    return res;
    
    })
    
    .catch(function(error){
    
    console.log(error);
    
    })
    
    .then(function (response) {
    
    console.log("success: ", response);
    
    
    });
    
    }
    
    function eliminarUsuario(id){
    
    fetch(url + id, {
    
    method: 'DELETE', // or 'PUT'
    
    headers:{
    
    'Content-Type': 'application/json'
    
    }
    
    }
    
    )
    
    .then(function(res){
    
    console.log(res);
    
    return res;
    
    })
    
    .catch(function(error){
    
    console.log(error);
    
    })
    
    .then(function (response) {
    
    console.log("success: ", response);
    
    
    });
}

function modificar(){

let Usuario = {};

Usuario.username = document.getElementById("username").value;

Usuario.password = document.getElementById("password").value;

Usuario.email = document.getElementById("email").value;

Usuario._id = document.getElementById("_id").value;;

fetch(url, {

method: 'PUT', // or 'PUT'

body: JSON.stringify(Usuario), // data can be `string` or {object}!

headers:{

'Content-Type': 'application/json'

}

}

)

.then(function(res){

console.log(res);

return res;

})

.catch(function(error){

console.log(error);

})

.then(function (response) {

console.log("success: ", response);


});

}

function login(){
    
    let username = document.getElementById("username").value;
    
    let password = document.getElementById("password").value;
    
    let Usuario = {};
    
    Usuario.username = username;
    
    Usuario.password = password;
    
    Usuario._id = null;  fetch(url, {

method: 'POST', // or 'PUT'
body: JSON.stringify(Usuario), // data can be `string` or {object}!
headers:{'Content-Type': 'application/json'}
}
)
.then(function(res){
console.log(res);
return res;
})
.catch(function(error){
console.log(error);
})
.then(function (response) {
console.log("success: ", response);
});
}