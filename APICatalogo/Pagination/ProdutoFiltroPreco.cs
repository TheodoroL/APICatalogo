namespace APICatalogo.Pagination;

public class ProdutoFiltroPreco : QueryParameters
{
    public decimal? Preco { get; set; }
    public string PrecoCriterio { get; set; } = string.Empty;// "maior", "menor", "igual"
}
