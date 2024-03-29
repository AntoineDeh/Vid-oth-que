using Microsoft.AspNetCore.Http.Json;
using Microsoft.OpenApi.Models;
using VideoTheque.Businesses.AgeRatings;
using VideoTheque.Businesses.Genres;
using VideoTheque.Businesses.Personnes;
using VideoTheque.Businesses.Supports;
using VideoTheque.Businesses.Films;
using VideoTheque.Context;
using VideoTheque.Core;
using VideoTheque.Repositories.AgeRatings;
using VideoTheque.Repositories.BluRays;
using VideoTheque.Repositories.Genres;
using VideoTheque.Repositories.Personnes;
using VideoTheque.Repositories.Supports;
using Mapster;
using System;
using VideoTheque;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Videotheque") ?? "Data Source=Videotheque.db";

// Add services to the container.

builder.Services.AddControllers();
builder.Services.RegisterMapsterConfiguration();

builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddSqlite<VideothequeDb>(connectionString);

builder.Services.AddScoped(typeof(IGenresRepository), typeof(GenresRepository));
builder.Services.AddScoped(typeof(IGenresBusiness), typeof(GenresBusiness));

builder.Services.AddScoped(typeof(ISupportsRepository), typeof(SupportsRepository));
builder.Services.AddScoped(typeof(ISupportsBusiness), typeof(SupportsBusiness));

builder.Services.AddScoped(typeof(IAgeRatingsRepository), typeof(AgeRatingsRepository));
builder.Services.AddScoped(typeof(IAgeRatingsBusiness), typeof(AgeRatingsBusiness));

builder.Services.AddScoped(typeof(IPersonnesRepository), typeof(PersonnesRepository));
builder.Services.AddScoped(typeof(IPersonnesBusiness), typeof(PersonnesBusiness));

builder.Services.AddScoped(typeof(IBluRaysRepository), typeof(BluRaysRepository));

builder.Services.AddScoped(typeof(IFilmsBusiness), typeof(FilmsBusiness));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Vid�oTh�que API",
        Description = "Gestion de sa collection de film.",
        Version = "v1"
    });
});

builder.Services.AddCors(option => option
    .AddDefaultPolicy(builder => builder
        .SetIsOriginAllowed(_=> true)
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Vid�oTh�que API V1");
    });
}

app.UseRouting();

//app.UseCors(builder => builder
//    .SetIsOriginAllowed(_ => true)
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .AllowCredentials()
//    );

app.UseCors();

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllers();

app.Run();