using APICatalogo.Data;
using APICatalogo.Interface;
using APICatalogo.Models;
using APICatalogo.Pagination;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Repository;

public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
{
    public CategoriaRepository(AppDataContext context) : base(context)
    {
    }

    public PagedList<Categoria> GetCategorias(CategoriasParameters categoriasParameters)
    {
        var categorias = GetAll().OrderBy(c => c.CategoriaId).AsQueryable();

        var categoriasOrdenadas = PagedList<Categoria>.ToPagedList(categorias, categoriasParameters.PageNumber, categoriasParameters.PageSize);

        return categoriasOrdenadas;
    }

    public PagedList<Categoria> GetCategoriasFiltroNome(CategoriasFiltroNome categoriasFiltroNome)
    {
        var categorias = GetAll().AsQueryable();
        if (!string.IsNullOrWhiteSpace(categoriasFiltroNome.Nome))
            categorias = categorias.Where(c => c.Nome.Contains(categoriasFiltroNome.Nome));

        var categoriasFiltradas = PagedList<Categoria>.ToPagedList(categorias, categoriasFiltroNome.PageNumber, categoriasFiltroNome.PageSize);
        return categoriasFiltradas;
    }

    public IEnumerable<Categoria> GetCategoriasProdutos()
    {
        return _context.Categorias
            .Include(p => p.Produtos)
            .AsNoTracking()
            .ToList();
    }

}
