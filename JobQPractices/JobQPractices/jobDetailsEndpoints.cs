using Microsoft.EntityFrameworkCore;
using JobQPractices.Data;
using JobQPractices.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace JobQPractices;

public static class jobDetailsEndpoints
{
    public static void MapjobDetailsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/jobDetails").WithTags(nameof(jobDetails));

        group.MapGet("/", async (JobQPracticesContext db) =>
        {
            return await db.jobDetails.ToListAsync();
        })
        .WithName("GetAlljobDetails")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<jobDetails>, NotFound>> (string id, JobQPracticesContext db) =>
        {
            return await db.jobDetails.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is jobDetails model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetjobDetailsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (string id, jobDetails jobDetails, JobQPracticesContext db) =>
        {
            var affected = await db.jobDetails
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, jobDetails.Id)
                  .SetProperty(m => m.Description, jobDetails.Description)
                  .SetProperty(m => m.JobStatus, jobDetails.JobStatus)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatejobDetails")
        .WithOpenApi();

        group.MapPost("/", async (jobDetails jobDetails, JobQPracticesContext db) =>
        {
            db.jobDetails.Add(jobDetails);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/jobDetails/{jobDetails.Id}",jobDetails);
        })
        .WithName("CreatejobDetails")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (string id, JobQPracticesContext db) =>
        {
            var affected = await db.jobDetails
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletejobDetails")
        .WithOpenApi();
    }
}
