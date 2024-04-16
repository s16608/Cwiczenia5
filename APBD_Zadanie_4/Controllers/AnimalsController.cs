using Microsoft.AspNetCore.Mvc;

namespace APBD_Zadanie_4.Controllers;

//routing matches a request URI to an action on a controller'
//once we send a http request the mvc framework
//tries to take uri and map it to a controller - prefer way is endpoint routing
[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Animal>> GetAnimals()
    {
        return Ok(AnimalsDataStore.Current.Animals);
    }

    [HttpGet("{id}")]
    public ActionResult<Animal> GetAnimal(int id)
    {
        var animalToReturn = AnimalsDataStore.Current.Animals.FirstOrDefault(x => x.Id == id);

        if (animalToReturn == null)
        {
            return NotFound();
        }
        return Ok(animalToReturn);
    }

    [HttpPost]
    public ActionResult<Animal> CreateAnimal([FromBody]Animal animal)
    {
        AnimalsDataStore.Current.Animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, Animal animal)
    {
        var animalToEdit = AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        AnimalsDataStore.Current.Animals.Remove(animalToEdit);
        AnimalsDataStore.Current.Animals.Add(animal);
        return NoContent();
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animalToDelete = AnimalsDataStore.Current.Animals.FirstOrDefault(animal => animal.Id == id);

        if (animalToDelete == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }
        AnimalsDataStore.Current.Animals.Remove(animalToDelete);
        return NoContent();
    }
}