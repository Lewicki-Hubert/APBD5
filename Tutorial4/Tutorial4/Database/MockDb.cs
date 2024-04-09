using Tutorial4.Models;

namespace Tutorial4.Database;

public class MockDb
{
    public List<Animal> Animals = new List<Animal>();

    public MockDb()
    {
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
        Animals.Add(new Animal());
    }
}