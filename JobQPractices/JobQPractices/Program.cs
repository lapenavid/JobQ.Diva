using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JobQPractices.Data;
using JobQPractices;
using JobQPractices.Data.ApsimData;
using JobQPractices.Interface;
using JobQPractices.repo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JobQPracticesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("JobQPracticesContext") ?? throw new InvalidOperationException("Connection string 'JobQPracticesContext' not found.")));

// Add services to the container.
builder.Services.AddSingleton<DataService>();
//builder.Services.AddScoped<ISimulationRepo, SimulationRepo>();
//builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapjobDetailsEndpoints();

app.Run();


