using APICatalogo.Models;
using APICatalogo.Pagination;

namespace APICatalogo.Interface;

public interface IProdutoRepository : IRepository<Produto>
{
    IEnumerable<Produto> GetProdutos(ProdutoParameters produtoParameters);
}
