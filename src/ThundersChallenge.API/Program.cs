using System.Text.Json.Serialization;
using ThundersChallenge.API.Filters;
using ThundersChallenge.Application;
using ThundersChallenge.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfraServices();

builder.Services
    .AddMvc(opt => opt.Filters.Add<NotificationFilter>())
    .AddJsonOptions( opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
