
using Loja;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var productService = new Loja.GetProduct();

app.MapGet("products", () => productService.GetProducts());

app.UseHttpsRedirection();
app.Run();