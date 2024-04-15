using Tutorial4.Models;

namespace Tutorial4.Database;

public class MockDb
{
    public List<Animal> Animals = new List<Animal>();
    public List<Visit> Visits = new List<Visit>();
        

    public MockDb()
    {
        Animals.Add(new Animal { Id = 1, Name = "Fido", Category = "Pies", Weight = 30.0, FurColor = "Czarny" });
        Visits.Add(new Visit { Id = 2, Date = DateTime.Now, Description = "Roczne szczepienie", Price = 150.0m, AnimalId = 1 });
    }
}