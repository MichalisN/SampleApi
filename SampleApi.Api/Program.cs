using Microsoft.EntityFrameworkCore;
using SampleApi.Data.Helpers;
using SampleApi.Data.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg => { cfg.AllowNullCollections = true; }, Assembly.GetExecutingAssembly());
builder.Services.AddDbContext<SampleApiContext>(opt => opt.UseInMemoryDatabase("SampleApiDB"));
builder.Services.AddScoped<ISampleEntityRepository, SampleEntityRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
