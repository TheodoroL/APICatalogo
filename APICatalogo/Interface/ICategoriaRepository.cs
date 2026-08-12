using APICatalogo.Models;

namespace APICatalogo.Interface;

public interface ICategoriaRepository : IRepository<Categoria>
{
    IEnumerable<Categoria> GetCategoriasProdutos();

}
