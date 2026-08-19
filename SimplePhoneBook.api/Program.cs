using SimplePhoneBook.api.Application.Services;
using SimplePhoneBook.api.Application.Services.Interfaces;
using SimplePhoneBook.api.Domain.Repositories;
using SimplePhoneBook.api.Infrastructure.Repositories.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ITagRepository, InMemoryTagRepository>();
builder.Services.AddSingleton<IContactRepository, InMemoryContactRepository>();

builder.Services.AddScoped<ITagService, TagService>();
builder.Services.AddScoped<IContactService, ContactService>();

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