using APICatalogo.Data;
using APICatalogo.Interface;
using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{

    public ProdutoRepository(AppDataContext context) : base(context)
    {

    }

    public IEnumerable<Produto> GetProdutos(ProdutoParameters produtoParameters)
    {
        return GetAll()
            .OrderBy(c => c.Nome)
            .Skip((produtoParameters.PageNumber - 1) * produtoParameters.PageSize)
            .Take(produtoParameters.PageSize)
            .ToList();
    }
}
