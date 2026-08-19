using SimplePhoneBook.api.Domain.Models;
using SimplePhoneBook.api.Domain.Repositories;
using SimplePhoneBook.api.Infrastructure.Repositories.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IEntityRepository<Contact>, InMemoryContactRepository>();
builder.Services.AddSingleton<IEntityRepository<Tag>, InMemoryTagRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();

app.Run();