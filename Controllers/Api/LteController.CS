using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

[ApiController]
[Route("api/lte")]

//6
public class LteController : Controller {
    [HttpGet("listar-registros-con-menos-100-personas-abordo")]
    public IActionResult Listarregistrosconmenos100personasabordo(){
        //Listar todos los registros con menos de 100 personas abordo

        MongoClient client = new MongoClient(CadenasConexion.MONGO_DB);
        var db = client.GetDatabase("Aeropuerto");
        var collection = db.GetCollection<Aeropuerto>("Vuelos");

        var filtro = Builders<Aeropuerto>.Filter.Lte(x => x.PasajerosActuales, 100);
        var lista = collection.Find(filtro).ToList();
        return Ok(lista);
    }
}