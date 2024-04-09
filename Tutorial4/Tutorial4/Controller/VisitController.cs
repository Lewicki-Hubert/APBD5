using Microsoft.AspNetCore.Mvc;
using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Controller;

[ApiController]
[Route("/visits")]
public class VisitsController : ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetVisit(int id)
    {
        StaticData.LoadRelationships(); // Upewnij się, że relacje są załadowane

        var visit = StaticData.Visits.FirstOrDefault(v => v.Id == id);
        if (visit == null)
        {
            return NotFound($"Visit with ID {id} not found.");
        }

        return Ok(visit);
    }

    [HttpGet]
    public IActionResult GetVisits()
    {
        StaticData.LoadRelationships(); // Upewnij się, że relacje są załadowane
        return Ok(StaticData.Visits);
    }

    [HttpPost]
    public IActionResult AddVisit([FromBody] Visit visit)
    {
        StaticData.Visits.Add(visit);
        return Created($"/visits/{visit.Id}", visit);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateVisit(int id, [FromBody] Visit updatedVisit)
    {
        var visit = StaticData.Visits.FirstOrDefault(v => v.Id == id);
        if (visit == null)
        {
            return NotFound();
        }

        visit.Date = updatedVisit.Date;
        visit.Description = updatedVisit.Description;
        visit.Price = updatedVisit.Price;
        visit.AnimalId = updatedVisit.AnimalId;
        return Ok(visit);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteVisit(int id)
    {
        var visit = StaticData.Visits.FirstOrDefault(v => v.Id == id);
        if (visit == null)
        {
            return NotFound();
        }

        StaticData.Visits.Remove(visit);
        return NoContent();
    }
}