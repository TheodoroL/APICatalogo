using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopularProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(@"
                INSERT INTO Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) 
                VALUES('Coca-Cola', 'Refrigerante de cola', 5.99, 'coca-cola.png', 100, NOW(), 1);
                ");
            mb.Sql(@"
                INSERT INTO Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) 
                VALUES('Roladinho de presunto', 'Lanche de presunto', 4.30, 'roladinho_presunto.png', 100, NOW(), 2);
                ");
            mb.Sql(@"
                INSERT INTO Produtos(Nome, Descricao, Preco, ImageUrl, Estoque, DataCadastro, CategoriaId) 
                VALUES('Pudim', 'Doce de pudim', 9.99, 'pudim.png', 100, NOW(), 3);
                ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Produtos");
        }
    }
}
