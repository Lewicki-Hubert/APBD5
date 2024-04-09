using Tutorial4.Database;
using Tutorial4.Models;

namespace Tutorial4.Endpoints;

public static class AnimalEndpoints
{
    public static void MapAnimalEndpoints(this WebApplication app)
    {
        app.MapGet("/animals", () =>
        {
            // 200 ok
            // 201 Created
            // 400 bad request
            // 401 Unauthorized
            // 403 Forbidden
            // 404 Not Found

            var animals = StaticData.animals;
            return Results.Ok();
        });

        app.MapGet("/animals/{id}", (int id) =>
        {
            return Results.Ok();
        });


        app.MapPost("/animals", (Animal animal) =>
        {
            return Results.Created("", animal);
        });
    }
}