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

    public PagedList<Produto> GetProdutos(ProdutoParameters produtoParameters)
    {
        var produtos = GetAll().OrderBy(p => p.ProdutoId).AsQueryable();

        var produtosOrdenados = PagedList<Produto>.ToPagedList(produtos, produtoParameters.PageNumber, produtoParameters.PageSize);

        return produtosOrdenados;
    }
}
