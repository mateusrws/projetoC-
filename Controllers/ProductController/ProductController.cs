using Loja.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Loja.Models.Product;

[ApiController]
[Route("/product")]
public class ProductController : ControllerBase
{
    private readonly AddDbContext _context;

    public ProductController(AddDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        if (id == null) return NotFound("Id não fornecido");
        var product = await _context.Products.FindAsync(id);
        if(product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ModelProduct product)
    {
        if(product == null)
        {
            return NotFound("Dados do produto não enviado");    
        }
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
        return Ok($"Produto cadastrado com sucesso: \nNome: {product.Name}\nPreco: {product.Price}\nQuantidade: {product.Qtd}");
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, ModelProduct data)
    {
        if (id == null) return NotFound("Id não fornecido");
        var product = await _context.Products.FindAsync(id);
        if(product == null) return NotFound("Não existe produto com esse id");

        product.Name = data.Name;
        product.Price = data.Price;

        await _context.SaveChangesAsync();
        return Ok(product);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null) return NotFound("Id não fornecido");
        var product = await _context.Products.FindAsync(id);
        if(product == null) return NotFound("Não existe produto com esse id");

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return Ok("Produto deletado");
    }
}