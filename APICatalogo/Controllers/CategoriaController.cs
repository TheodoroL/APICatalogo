using APICatalogo.Data;
using APICatalogo.DTOS;
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
    public ActionResult<IEnumerable<CategoriaDTO>> GetCategorias() => Ok(_unitOfWork.CategoriaRepository.GetAll());


    [HttpGet("{id:int}", Name = "ObterCategoria")]

    public ActionResult<CategoriaDTO> GetCategoria(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);
        if (categoria is null) return NotFound();

        var categoriaDTO = new CategoriaDTO
        {
            CategoriaId = categoria.CategoriaId,
            Nome = categoria.Nome,
            ImageUrl = categoria.ImageUrl
        };

        return Ok(categoriaDTO);
    }

    [HttpPost]
    public ActionResult PostCategoria(CategoriaDTO categoriaDTO)
    {
        if (categoriaDTO == null) return BadRequest();

        var categoria = new Categoria
        {
            CategoriaId = categoriaDTO.CategoriaId,
            Nome = categoriaDTO.Nome,
            ImageUrl = categoriaDTO.ImageUrl
        };
        var categoriaCriada = _unitOfWork.CategoriaRepository.Create(categoria);

        return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaCriada.CategoriaId }, categoriaCriada);
    }

    [HttpPut("{id:int}")]
    public ActionResult PutCategoria(int id, CategoriaDTO categoriaDTO)
    {
        if (id != categoriaDTO.CategoriaId) return BadRequest();

        var categoria = new Categoria
        {
            CategoriaId = categoriaDTO.CategoriaId,
            Nome = categoriaDTO.Nome,
            ImageUrl = categoriaDTO.ImageUrl
        };
        var categoriaAtualizada = _unitOfWork.CategoriaRepository.Update(categoria);
        return Ok(categoriaAtualizada);
    }


    [HttpDelete("{id:int}")]
    public ActionResult<CategoriaDTO> DeleteCategoria(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.Get(c => c.CategoriaId == id);

        if (categoria is null) return NotFound();

        _unitOfWork.CategoriaRepository.Delete(categoria);

        return Ok(categoria);
    }
}
