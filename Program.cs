using Loja.Data;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
Env.Load();


var builder = WebApplication.CreateBuilder(args);

var connectionString = Env.GetString("ConnectionStrings__DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' não encontrado");

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AddDbContext>(opts => opts.UseNpgsql(connectionString));


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapControllers();
app.UseHttpsRedirection();
app.Run();