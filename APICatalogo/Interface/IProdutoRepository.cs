using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Interface;

public interface IProdutoRepository : IRepository<Produto>
{
    PagedList<Produto> GetProdutos(ProdutoParameters produtoParameters);
}
