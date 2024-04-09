using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;
using System.Linq;

namespace Tutorial4.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalsController : ControllerBase
{
    // Metoda GET do pobierania wszystkich zwierząt
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(StaticData.Animals);
    }

    // Metoda GET do pobierania pojedynczego zwierzęcia po ID
    [HttpGet("{id}")]
    public IActionResult GetAnimal(int id)
    {
        var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with ID {id} not found.");
        }
        return Ok(animal);
    }

    // Metoda POST do dodawania nowego zwierzęcia
    [HttpPost]
    public IActionResult AddAnimal([FromBody] Animal animal)
    {
        // Przykład prostej walidacji - w praktyce może być potrzebna bardziej złożona logika
        if (animal == null || string.IsNullOrEmpty(animal.Name))
        {
            return BadRequest("Animal data is incomplete.");
        }

        // Dodanie zwierzęcia do listy (przykład bez rzeczywistej bazy danych)
        animal.Id = StaticData.Animals.Max(a => a.Id) + 1;  // Proste generowanie ID
        StaticData.Animals.Add(animal);
        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    // Metoda PUT do aktualizacji danych zwierzęcia
    [HttpPut("{id}")]
    public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
    {
        var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with ID {id} not found.");
        }

        // Aktualizacja danych zwierzęcia
        animal.Name = updatedAnimal.Name;
        animal.Category = updatedAnimal.Category;
        animal.Weight = updatedAnimal.Weight;
        animal.FurColor = updatedAnimal.FurColor;
        return Ok(animal);
    }

    // Metoda DELETE do usuwania zwierzęcia
    [HttpDelete("{id}")]
    public IActionResult DeleteAnimal(int id)
    {
        var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
        if (animal == null)
        {
            return NotFound($"Animal with ID {id} not found.");
        }
        StaticData.Animals.Remove(animal);
        return NoContent();  // Kod 204, gdy zasób został usunięty
    }
}
