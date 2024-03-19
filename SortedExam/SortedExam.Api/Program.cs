using Microsoft.OpenApi.Models;
using SortedExam.Api.Filters;
using SortedExam.Model.App.Shared;
using SortedExam.Service;

var builder = WebApplication.CreateBuilder(args);

var configurationOption = new ConfigurationOption();
builder.Configuration.Bind("ConfigurationOption", configurationOption); 
builder.Services.AddSingleton(configurationOption);

builder.Services.AddControllers();
builder.Services.AddCoreServices(configurationOption);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "1.0",
        Title = "Rainfall Api", 
        Description = "An API which provides rainfall reading data",
        Contact = new OpenApiContact() { 
            Name = "Sorted", 
            Url = new Uri("https://www.sorted.com")
        }
    });
    c.AddServer(new OpenApiServer { Url = "https://localhost:3000", Description = "Rainfall Api" });
    c.OperationFilter<SwaggerOperationFilter>();
    c.EnableAnnotations();
});

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
