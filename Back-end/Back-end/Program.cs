using Back_end.Models;
using Back_end.Repositories;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<DbConnection>();


builder.Services.AddSingleton<IProductModelRepository, ProductModelRepository>();
//builder.Services.AddSingleton<IVideogame_Movie_Service, Videogame_Movie_Service>();

var app = builder.Build();


app.MapControllers();

app.Run();
