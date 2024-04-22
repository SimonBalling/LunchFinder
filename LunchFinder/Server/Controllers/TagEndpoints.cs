using Microsoft.EntityFrameworkCore;
using LunchFinder.Server.Data;
using LunchFinder.Shared.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace LunchFinder.Server.Controllers;

public static class TagEndpoints
{
    public static void MapTagEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Tags").WithTags(nameof(Tag));

        group.MapGet("/", async (LunchFinderServerContext db) =>
        {
            return await db.Tags.ToListAsync();
        })
        .WithName("GetAllTags")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Tag>, NotFound>> (int id, LunchFinderServerContext db) =>
        {
            return await db.Tags.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Tag model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTagById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Tag tag, LunchFinderServerContext db) =>
        {
            var affected = await db.Tags
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Name, tag.Name)
                    .SetProperty(m => m.Description, tag.Description)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTag")
        .WithOpenApi();

        group.MapPost("/", async (Tag tag, LunchFinderServerContext db) =>
        {
            db.Tags.Add(tag);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Tags/{tag.Id}",tag);
        })
        .WithName("CreateTag")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, LunchFinderServerContext db) =>
        {
            var affected = await db.Tags
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTag")
        .WithOpenApi();
    }
}
