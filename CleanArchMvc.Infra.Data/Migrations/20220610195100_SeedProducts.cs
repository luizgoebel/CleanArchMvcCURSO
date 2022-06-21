using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchMvc.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) Values ('Caderno espiral','Caderno espiral 100 folhas',7.45,50,'caderno1.jpg',1)");
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) Values ('Estojo escolar','Estojo escolar cinza',5.65,70,'Estojo1.jpg',1)");
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) Values ('Borracha escolar','Borracha escolar branca pequena',3.25,80,'borracha1.jpg',1)");
            mb.Sql("INSERT INTO Products(Name,Description,Price,Stock,Image,CategoryId) Values ('Calculadora escolar','Calculadora escolar simples',15.39,20,'calculadora1.jpg',2)");
        }

        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Products");
        }
    }
}
