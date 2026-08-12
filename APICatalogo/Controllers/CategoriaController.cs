using APICatalogo.Data;
using APICatalogo.Interface;
using APICatalogo.Models;
using APICatalogo.Services;
using Microsoft.AspNetCore.Mvc;

namespace APICatalogo.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriaController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUnitOfWork _unitOfWork;
    public CategoriaController(AppDataContext context, IConfiguration configuration, IUnitOfWork unitOfWork)
    {
        _configuration = configuration;
        _unitOfWork = unitOfWork;
    }


    [HttpGet("LerArquivoConfiguracao")]
    public ActionResult<string> LerArquivoConfiguracao()
    {
        var chave1 = _configuration["chave1"];
        var chave2 = _configuration["chave2"];
        var listaChave2 = _configuration["listaChave:chave2"];
        return $"chave1 = {chave1}\nchave2 = {chave2}\nListaChave=> chcave2 = {listaChave2}";
    }

    [HttpGet("usandoFromService/{nome}")]
    public ActionResult<string> GetSaudacao([FromServices] IMeuServicoe meuServico, string nome) => meuServico.Saudacao(nome);

    [HttpGet("semFromService/{nome}")]
    public ActionResult<string> GetSaudacaoSemFromService(IMeuServicoe meuServico, string nome) => meuServico.Saudacao(nome);


    [HttpGet("produtos")]
    public ActionResult GetCategoriasProdutos() => Ok(_unitOfWork.CategoriaRepository.GetCategoriasProdutos());


    [HttpGet]
    public ActionResult GetCategorias() => Ok(_unitOfWork.CategoriaRepository.GetAll());


    [HttpGet("{id:int}", Name = "ObterCategoria")]

    public ActionResult GetCategoria(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
        if (categoria is null) return NotFound();
        return Ok(categoria);
    }

    [HttpPost]
    public ActionResult PostCategoria(Categoria categoria)
    {
        if (categoria == null) return BadRequest();
        var categoriaCriada = _unitOfWork.CategoriaRepository.Create(categoria);

        return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaCriada.CategoriaId }, categoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult PutCategoria(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId) return BadRequest();

        var categoriaAtualizada = _unitOfWork.CategoriaRepository.Update(categoria);
        return Ok(categoriaAtualizada);
    }


    [HttpDelete("{id:int}")]
    public ActionResult DeleteCategoria(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null) return NotFound();

        _unitOfWork.CategoriaRepository.Delete(categoria);

        return Ok(categoria);
    }
}
