using produtoapi2.Models;

namespace produtoapi2.Interfaces;

public interface IProdutoService
{
    void Criar(Produto produto);
    List<Produto> Listar();
    Produto? BuscarPorId(int id);
    void Atualizar(Produto produto);
    void Deletar(int id);
}
