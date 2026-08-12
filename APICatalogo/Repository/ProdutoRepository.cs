using APICatalogo.Data;
using APICatalogo.Interface;
using APICatalogo.Models;

namespace APICatalogo.Repository;

public class ProdutoRepository : Repository<Produto>, IProdutoRepository
{

    public ProdutoRepository(AppDataContext context) : base(context)
    {

    }


}
