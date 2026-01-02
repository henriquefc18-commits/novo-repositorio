using Microsoft.EntityFrameworkCore;
using produtoapi2.Data;
using produtoapi2.Interfaces;
using produtoapi2.Models;

namespace produtoapi2.Repository;

public class ProdutoRepository(AppDbContext dbContext) : IProdutoRepository
{
    private readonly AppDbContext _dbContext = dbContext;

    public void Add(Produto produto)
    {
        _dbContext.Produtos.Add(produto);
        _dbContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var produto = _dbContext.Produtos.Find(id);
        if (produto == null) return;

        _dbContext.Produtos.Remove(produto);
        _dbContext.SaveChanges();
    }

    public List<Produto> GetAll()
        => _dbContext.Produtos.ToList();

    public Produto? GetById(int id)
        => _dbContext.Produtos.FirstOrDefault(p => p.Id == id);

    public void Update(Produto produto)
    {
        _dbContext.ChangeTracker.Clear();

        _dbContext.Entry(produto).State = EntityState.Modified;
        _dbContext.SaveChanges();
    }
}
