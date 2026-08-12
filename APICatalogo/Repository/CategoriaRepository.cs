using APICatalogo.Data;
using APICatalogo.Interface;
using APICatalogo.Models;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDataContext context) : base(context)
    {
    }

    public IEnumerable<Categoria> GetCategoriasProdutos()
    {
        return _context.Categorias
            .Include(p => p.Produtos)
            .AsNoTracking()
            .ToList();
    }

}
