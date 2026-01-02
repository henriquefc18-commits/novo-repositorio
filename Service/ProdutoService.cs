using produtoapi2.Interfaces;
using produtoapi2.Models;

namespace produtoapi2.Service;

public class ProdutoService : IProdutoService
{

    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }


    public void Atualizar(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome))
            throw new Exception("O nome do produto é obrigatório");

        if (produto.Preco < 0)
            throw new Exception("O preço não pode ser negativo");

        if (produto.Quantidade < 0)
            throw new Exception("Quantidade inválida");

        _produtoRepository.Update(produto);
    }

    public Produto? BuscarPorId(int id) => _produtoRepository.GetById(id);

    public void Criar(Produto produto)
    {
        if (string.IsNullOrWhiteSpace(produto.Nome))
            throw new Exception("O nome do produto é obrigatório");

        if (produto.Preco < 0)
            throw new Exception("O preço não pode ser negativo");

        if (produto.Quantidade < 0)
            throw new Exception("Quantidade inválida");

        _produtoRepository.Add(produto);
    }

    public void Deletar(int id) => _produtoRepository.Delete(id);

    public List<Produto> Listar() => _produtoRepository.GetAll();
}
