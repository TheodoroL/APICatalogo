using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APICatalogo.Migrations
{
    /// <inheritdoc />
    public partial class PopularCategorias : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Categorias(Nome, ImageUrl) VALUES('Bebidas','bebidas.png')");
            mb.Sql("INSERT INTO Categorias(Nome, ImageUrl) VALUES('Lanches','lanches.png')");
            mb.Sql("INSERT INTO Categorias(Nome, ImageUrl) VALUES('Sobremesas','sobremesas.png')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Categorias");
        }
    }
}
