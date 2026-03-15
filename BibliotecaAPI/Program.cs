using BibliotecaAPI.Data;
using BibliotecaAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//área de servicios;

builder.Services.AddTransient<IValoresRepositories, ValoresRepositories>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    )
);



var app = builder.Build();

// area de middlewares

app.MapControllers();

app.Run();
