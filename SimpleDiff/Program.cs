using Microsoft.EntityFrameworkCore;
using SimpleDiff.Data;
using SimpleDiff.Diff;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DiffContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("WebApiDatabase")));
builder.Services.AddScoped<IDiffItemStore, DiffItemStore>();

builder.Services.AddScoped<DiffItemManager>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    DbInitialiser.Initialize(scope.ServiceProvider.GetRequiredService<DiffContext>());
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }