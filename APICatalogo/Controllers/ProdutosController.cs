using APICatalogo.Filters;
using APICatalogo.Interface;
using APICatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProdutosController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public ActionResult<IEnumerable<Produto>> GetProdutosAsync()
    {
        var produtos = _unitOfWork.ProdutoRepository.GetAll();

        if (produtos is null) BadRequest();

        return Ok(produtos);
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<Produto> GetProdutoAsync(int id)
    {
        var produto = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);

        if (produto == null) return NotFound(new { message = "produto não encontrado" });

        return Ok(produto);
    }

    [HttpPost]
    public ActionResult<Produto> PostProduto(Produto produto)
    {
        if (produto == null) return BadRequest();


        var novoProduto = _unitOfWork.ProdutoRepository.Create(produto);

        return new CreatedAtRouteResult("ObterProduto", new { id = novoProduto.ProdutoId }, novoProduto);
    }

    [HttpPut("{id}")]
    public ActionResult PutProduto(int id, Produto produto)
    {

        if (id != produto.ProdutoId) return BadRequest();

        var atualizarProduto = _unitOfWork.ProdutoRepository.Update(produto);

        if (atualizarProduto is null) return NotFound(new { message = "produto não encontrado" });

        return Ok(produto);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteProduto(int id)
    {
        var produto = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);

        if (produto is null) return NotFound(new { message = "produto não encontrado" });

        _unitOfWork.ProdutoRepository.Delete(produto);

        return Ok();
    }
}
