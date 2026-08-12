using APICatalogo.Data;
using APICatalogo.Interface;

namespace APICatalogo.Repository;

public class UnitOfWork : IUnitOfWork
{
    private IProdutoRepository _produtoRepository;
    private ICategoriaRepository _categoriaRepository;

    public IProdutoRepository ProdutoRepository
    {

        get
        {
            return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
        }
        set
        {
            _produtoRepository = value;
        }
    }

    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
        }
        set
        {
            _categoriaRepository = value;
        }
    }
    public AppDataContext _context;

    public UnitOfWork(AppDataContext context)
    {
        _context = context;
    }

    public void Commit()
    {
        _context.SaveChanges();
    }
    public void Dispose()
    {
        //faz endo a liberação de recursos do contexto, liberando memória e fechando conexões com o banco de dados
        _context.Dispose();
    }
}
