using APICatalogo.DTOS;
using APICatalogo.Filters;
using APICatalogo.Interface;
using APICatalogo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public ProdutosController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ServiceFilter(typeof(ApiLoggingFilter))]
    public ActionResult<IEnumerable<ProdutoDTO>> GetProdutosAsync()
    {
        var produtos = _unitOfWork.ProdutoRepository.GetAll();

        if (produtos is null) BadRequest();

        var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);

        return Ok(produtosDTO);
    }

    [HttpGet("{id:int:min(1)}", Name = "ObterProduto")]
    public ActionResult<ProdutoDTO> GetProdutoAsync(int id)
    {
        var produto = _unitOfWork.ProdutoRepository.Get(p => p.ProdutoId == id);

        if (produto == null) return NotFound(new { message = "produto não encontrado" });

        var produtoDTO = _mapper.Map<ProdutoDTO>(produto);

        return Ok(produtoDTO);
    }

    [HttpPost]
    public ActionResult<ProdutoDTO> PostProduto(ProdutoDTO produto)
    {
        if (produto == null) return BadRequest();

        var produtoEntity = _mapper.Map<Produto>(produto);

        var novoProduto = _unitOfWork.ProdutoRepository.Create(produtoEntity);

        var novoProdutoDTO = _mapper.Map<ProdutoDTO>(novoProduto);

        return new CreatedAtRouteResult("ObterProduto", new { id = novoProdutoDTO.ProdutoId }, novoProdutoDTO);
    }

    [HttpPut("{id}")]
    public ActionResult PutProduto(int id, ProdutoDTO produto)
    {

        if (id != produto.ProdutoId) return BadRequest();

        var produtoEntity = _mapper.Map<Produto>(produto);
        var atualizarProduto = _unitOfWork.ProdutoRepository.Update(produtoEntity);

        if (atualizarProduto is null) return NotFound(new { message = "produto não encontrado" });

        var produtoDTO = _mapper.Map<ProdutoDTO>(atualizarProduto);

        return Ok(produtoDTO);
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
