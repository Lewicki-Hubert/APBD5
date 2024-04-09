using Tutorial4.Models;
using System.Collections.Generic;

namespace Tutorial4.Database;

public static class StaticData
{
    public static List<Animal> Animals { get; } = new List<Animal>();
    public static List<Visit> Visits { get; } = new List<Visit>();

    static StaticData()
    {
        Animals.Add(new Animal { Id = 1, Name = "Fido", Category = "Pies", Weight = 30.0, FurColor = "Brązowy" });
        Animals.Add(new Animal { Id = 2, Name = "Whiskers", Category = "Kot", Weight = 5.0, FurColor = "Szary" });

        Visits.Add(new Visit
        {
            Id = 1, AnimalId = 1, Date = System.DateTime.Now, Description = "Roczne szczepienie", Price = 150.0m
        });
        Visits.Add(new Visit
        {
            Id = 2, AnimalId = 2, Date = System.DateTime.Now.AddDays(-10), Description = "Kontrola zdrowia",
            Price = 100.0m
        });
    }

    public static void LoadRelationships()
    {
        foreach (var visit in Visits)
        {
            visit.Animal = Animals.FirstOrDefault(a => a.Id == visit.AnimalId);
        }
    }
}