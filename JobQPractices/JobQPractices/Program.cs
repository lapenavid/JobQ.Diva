using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JobQPractices.Data;
using JobQPractices;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JobQPracticesContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("JobQPracticesContext") ?? throw new InvalidOperationException("Connection string 'JobQPracticesContext' not found.")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

IDataServices dataServices = new DataService();
DataHandler handler = new DataHandler(dataServices);
handler.sendData("message");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapjobDetailsEndpoints();

app.Run();


