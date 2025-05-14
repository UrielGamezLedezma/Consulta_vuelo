using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[Route("api/vuelos")]
public class VuelosController : ControllerBase{

[HttpGet("ciudad-origen")]
public IActionResult CiudadOrigen(){
var client = new MongoClient(CadenaConexion.MONGO_DB);
var db = client.GetDatabase("Aeropuerto");
var collection = db.GetCollection<Vuelo>("Vuelos");

var lista = collection.Distinct<string>("CiudadOrigen", FilterDefinition<Vuelo>.Empty).ToList();

return Ok(lista);
   }


[HttpGet("ciudad-destino")]
public IActionResult CiudadDestino(){
var client = new MongoClient(CadenaConexion.MONGO_DB);
var db = client.GetDatabase("Aeropuerto");
var collection = db.GetCollection<Vuelo>("Vuelos");

var lista = collection.Distinct<string>("CiudadDestino", FilterDefinition<Vuelo>.Empty).ToList();


return Ok();
   }

   [HttpGet("estatus")]
public IActionResult ListarEstatus(){
   var client = new MongoClient(CadenaConexion.MONGO_DB);
var db = client.GetDatabase("Aeropuerto");
var collection = db.GetCollection<Vuelo>("Vuelos");

var lista = collection.Distinct<string>("EstatusVuelo", FilterDefinition<Vuelo>.Empty).ToList();


return Ok();
   }

[HttpGet("listar-vuelos")]
public IActionResult ListarVuelos(string estatus, string? origen, string? destino, string? fechaInicial, string? fechaFinal){
var client = new MongoClient(CadenaConexion.MONGO_DB);
var db = client.GetDatabase("Aeropuerto");
var collection = db.GetCollection<Vuelo>("Vuelos");

List<FilterDefinition<Vuelo>> filters = new List<FilterDefinition<Vuelo>>();

if(!string.IsNullOrWhiteSpace(estatus)){
var filterEstatus = Builders<Vuelo>.Filter.Eq(x => x.EstatusVuelo, estatus );
filters.Add(filterEstatus);
}

if(!string.IsNullOrWhiteSpace(origen)){
var filterOrigen = Builders<Vuelo>.Filter.Eq(x => x.CiudadOrigen, origen );
filters.Add(filterOrigen);
}

if(!string.IsNullOrWhiteSpace(destino)){
var filterDestino = Builders<Vuelo>.Filter.Eq(x => x.CiudadDestino, destino );
filters.Add(filterDestino);
}

if (!string.IsNullOrWhiteSpace(fechaInicial)){
   
}
List<Vuelo> vuelos;
if(filters.Count > 0) {
   var filter = Builders<Vuelo>.Filter.And(filters);
   vuelos = collection.Find(filter).ToList();
}
else{
   vuelos = collection.Find(FilterDefinition<Vuelo>.Empty).ToList();
}
return Ok(vuelos);
   }
}