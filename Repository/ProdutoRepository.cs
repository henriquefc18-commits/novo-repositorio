using produtoapi2.Data;

namespace produtoapi2.Repository;

public class ProdutoRepository(AppDbContext dbContext)
{
    //Para que possamos ter acesso ao banco de dados, precisamos injetar o AppDbContext
    private AppDbContext _dbContext = dbContext;

    // Aqui implementaremos os metodos definidos na interface IProdutoRepository
    // Não esqueça que devemos herdar a interface aqui
    // Na repository geralmente colocamos o acesso a dados da aplicação
    // consultas ao banco de dados, etc. Utiliza o entity framework, pois
    // estamos utilizndo inMemory database
}
