using Microsoft.EntityFrameworkCore;
using Loja.Models.Product;
using Loja.Models.User;


namespace Loja.Data;

public class AddDbContext : DbContext
{
    public AddDbContext(DbContextOptions<AddDbContext> options) : base(options)
    {

    }

    public DbSet<ModelProduct> Products { get; set; }
    public DbSet<ModelUser> Users { get; set; }
}