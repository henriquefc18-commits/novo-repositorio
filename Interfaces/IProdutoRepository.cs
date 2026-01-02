using produtoapi2.Models;

namespace produtoapi2.Interfaces;

public interface IProdutoRepository
{
    void Add(Produto produto);
    List<Produto> GetAll();
    Produto? GetById(int id);
    void Update(Produto produto);
    void Delete(int id);
}
