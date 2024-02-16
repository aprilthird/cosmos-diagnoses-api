using Cosmos.Diagnoses.Api.CrossCutting.Settings;
using Cosmos.Diagnoses.Api.Domain.Repositories;
using Cosmos.Diagnoses.Api.Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Text.Json;
using Cosmos.Diagnoses.Api.Infrastructure.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AppSettings>(builder.Configuration.Bind);

builder.Services.AddScoped<IPatientDiagnosisRepository, PatientDiagnosisRepository>();
builder.Services.AddScoped<ICIE10CodeRepository, CIE10CodeRepository>();

builder.Services.AddSingleton((provider) =>
{
    JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.Never,
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        //PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    var cosmosClientOptions = new CosmosClientOptions()
    {
        ConnectionMode = ConnectionMode.Direct,
        Serializer = new CosmosSystemTextJsonSerializer(options)
    };

    return new CosmosClient(builder.Configuration.GetConnectionString("CosmosDB"), cosmosClientOptions);
});

builder.Services.AddControllers();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
