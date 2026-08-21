using APICatalogo.DTOS;
using APICatalogo.Models;
using AutoMapper;

namespace APICatalogo.Mapping;

public class ProdutoDTOAutoMappingProfile : Profile
{
    public ProdutoDTOAutoMappingProfile()
    {
        //Cria o mapeamento tanto pra produto, tanto para ProdutoDTO
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateRequest>().ReverseMap();
        CreateMap<Produto, ProdutoDTOUpdateResponse>().ReverseMap();
        //Cria o mapeamento tanto pra Categoria, tanto para CategoriaDTO
        CreateMap<Categoria, CategoriaDTO>().ReverseMap();
    }
}
