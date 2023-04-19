using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Movies.Application.Handlers;
using Movies.Core.Repositories;
using Movies.Core.Repositories.Base;
using Movies.Infrastructure.Data;
using Movies.Infrastructure.Repositories;
using Movies.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Movie API", Version = "v1" });
});

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});

builder.Services.AddVersionedApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddDbContext<MovieContext>(
    m => m.UseSqlServer(configuration.GetConnectionString("MovieConnString")),
    ServiceLifetime.Singleton
);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateMovieCommandHandler).Assembly));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddLogging(builder =>
{
    builder.AddConsole();
    builder.AddDebug();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Movie API");
    });
}

//app.UseHttpsRedirection();
app.UseHttpLogging();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(a => a.MapControllers());
app.UseApiVersioning();

//await SeedDbAsync(app);
app.Run();





static async Task SeedDbAsync(WebApplication host)
{
    var loggerFactory = host.Services.GetRequiredService<LoggerFactory>();
    try
    {
        var context = host.Services.GetRequiredService<MovieContext>();
        await MovieContextSeed.SeedAsync(context, loggerFactory);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError("Exception seeding data... {Message}", ex.Message);
    }
}

