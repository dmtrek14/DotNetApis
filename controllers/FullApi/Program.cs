using Microsoft.OpenApi.Models;
using NLog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
Logger logger = LogManager.GetCurrentClassLogger();

//TODO: Add db connection

//TODO: Add services to the container

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{

	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = $"v{Assembly.GetExecutingAssembly().GetName().Version}",
		Title = "FullApi",
		Description = $"A sample controller-style web API using schema for DnD data.",
	});

	var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
	options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

var env = app.Environment.IsDevelopment() ? "Development" : "Production";

logger.Info($"FullApi starting: {env}");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI(options =>
	{
		options.SwaggerEndpoint("./swagger/v1/swagger.json", "v1");
		options.RoutePrefix = "";
	});
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
