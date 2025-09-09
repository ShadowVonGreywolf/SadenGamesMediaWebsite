using Back_end.Models;
using Back_end.Repositories;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<DbConnection>();


builder.Services.AddSingleton<IProductModelRepository, ProductModelRepository>();

var app = builder.Build();


app.MapControllers();

app.Run();
