namespace ProyectoInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Articulo", "id_tipo_inventario");
            CreateIndex("dbo.transaccion", "id_articulo");
            AddForeignKey("dbo.Articulo", "id_tipo_inventario", "dbo.tipo_inventario", "id_tipo_inventario", cascadeDelete: true);
            AddForeignKey("dbo.transaccion", "id_articulo", "dbo.Articulo", "id_articulo", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.transaccion", "id_articulo", "dbo.Articulo");
            DropForeignKey("dbo.Articulo", "id_tipo_inventario", "dbo.tipo_inventario");
            DropIndex("dbo.transaccion", new[] { "id_articulo" });
            DropIndex("dbo.Articulo", new[] { "id_tipo_inventario" });
        }
    }
}
