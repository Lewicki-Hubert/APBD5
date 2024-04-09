using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app, MockDb db)
    {
        app.MapGet("/animals", () => Results.Ok(db.Animals));

        app.MapGet("/animals/{id}", (int id) =>
        {
            var animal = StaticData.Animals.FirstOrDefault(a => a.Id == id);
            if (animal != null)
            {
                return Results.Ok();
            }

            return Results.NotFound();
        });

        app.MapPost("/animals", (Animal animal) =>
        {
            db.Animals.Add(animal);
            return Results.Created($"/animals/{animal.Id}", animal);
        });

        app.MapPut("/animals", (int id, Animal updatedAnimal) =>
        {
            var animal = db.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return Results.NotFound();
            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.FurColor = updatedAnimal.FurColor;
            return Results.Ok(animal);
        });

        app.MapDelete("/animals", (int id) =>
        {
            var animal = db.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null) return Results.NotFound();
            db.Animals.Remove(animal);
            return Results.NoContent();
        });
    }

    public static void MapVisitEndpoints(this WebApplication app, MockDb db)
    {
        app.MapGet("/visits", () => Results.Ok(db.Visits));

        app.MapGet("/visits/{id}", (int id) =>
        {
            var visit = db.Visits.FirstOrDefault(v => v.Id == id);
            return visit != null ? Results.Ok(visit) : Results.NotFound();
        });

        app.MapPost("/visits", (Visit visit) =>
        {
            db.Visits.Add(visit);
            return Results.Created($"/visits/{visit.Id}", visit);
        });
    }
}