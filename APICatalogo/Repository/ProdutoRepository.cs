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

    public PagedList<Produto> GetProdutosFiltroPreco(ProdutoFiltroPreco produtoFiltroPreco)
    {
        var produtos = GetAll().AsQueryable();

        if (!produtoFiltroPreco.Preco.HasValue && string.IsNullOrEmpty(produtoFiltroPreco.PrecoCriterio))
            throw new NotImplementedException();


        if (produtoFiltroPreco.PrecoCriterio.Equals("maior", StringComparison.OrdinalIgnoreCase))
            produtos = produtos.Where(p => p.Preco > produtoFiltroPreco.Preco);

        else if (produtoFiltroPreco.PrecoCriterio.Equals("menor", StringComparison.OrdinalIgnoreCase))
            produtos = produtos.Where(p => p.Preco < produtoFiltroPreco.Preco);

        else if (produtoFiltroPreco.PrecoCriterio.Equals("igual", StringComparison.OrdinalIgnoreCase))
            produtos = produtos.Where(p => p.Preco == produtoFiltroPreco.Preco);


        var produtosOrdenados = PagedList<Produto>.ToPagedList(produtos, produtoFiltroPreco.PageNumber, produtoFiltroPreco.PageSize);

        return produtosOrdenados;
    }
}
