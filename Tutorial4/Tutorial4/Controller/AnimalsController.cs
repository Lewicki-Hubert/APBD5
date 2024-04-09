using Microsoft.AspNetCore.Mvc;

namespace Tutorial4.Controller;

[ApiController]
[Route("/animals-controller")]
//[Route("[controller]")]
public class AnimalsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok();
    }
    
    
    [HttpGet("{id}")]
    public IActionResult GetAnimals(int id)
    {
        return Ok();
    }
    
    [HttpPost]
    public IActionResult AddAnimals()
    {
        return Ok();
    }
}