using Microsoft.EntityFrameworkCore;
using LunchFinder.Server.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace LunchFinder.Server.Places;

public static class PlaceEndpoints
{
    public static void MapPlaceEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Place").WithTags(nameof(Place));

        group.MapGet("/", async (LunchFinderServerContext db) =>
        {
            return await db.Places.ToListAsync();
        })
        .WithName("GetAllPlaces")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Place>, NotFound>> (int id, LunchFinderServerContext db) =>
        {
            return await db.Places.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Place model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPlaceById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Place place, LunchFinderServerContext db) =>
        {
            var affected = await db.Places
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, place.Id)
                    .SetProperty(m => m.Name, place.Name)
                    .SetProperty(m => m.Description, place.Description)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePlace")
        .WithOpenApi();

        group.MapPost("/", async (Place place, LunchFinderServerContext db) =>
        {
            db.Places.Add(place);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Place/{place.Id}",place);
        })
        .WithName("CreatePlace")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, LunchFinderServerContext db) =>
        {
            var affected = await db.Places
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePlace")
        .WithOpenApi();
    }
}
