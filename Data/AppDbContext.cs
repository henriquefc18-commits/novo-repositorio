using Microsoft.EntityFrameworkCore;
using produtoapi2.Models;

namespace produtoapi2.Data;

public class AppDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Produto>().HasData(
            new Produto { Id = 1, Nome = "Produto 1", Descricao = "Descrição 1", Preco = 10.99m, Quantidade = 100 },
            new Produto { Id = 2, Nome = "Produto 2", Descricao = "Descrição 2", Preco = 25.50m, Quantidade = 50 }
        );
    }
}
