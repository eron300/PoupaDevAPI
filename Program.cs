using Microsoft.EntityFrameworkCore;
using PoupaDev.API.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Adicionando o objetivo PoupaDevContext como uma instância Singleton de maneira que posso utilizar
// como um banco de dados em memória
//builder.Services.AddSingleton<PoupaDevContext>();
var connectionString = builder.Configuration.GetConnectionString("PoupaDevCs");

builder.Services.AddDbContext<PoupaDevContext>(o => o.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
