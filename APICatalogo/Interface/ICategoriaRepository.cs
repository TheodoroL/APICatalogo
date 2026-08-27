using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Interface;

public interface ICategoriaRepository : IRepository<Categoria>
{
    public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters);
    IEnumerable<Categoria> GetCategoriasProdutos();

}
