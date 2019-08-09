namespace ProyectoInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.almacen",
                c => new
                    {
                        id_almacen = c.Int(nullable: false, identity: true),
                        descripcion_almacen = c.String(nullable: false),
                        estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id_almacen);
            
            CreateTable(
                "dbo.Articulo",
                c => new
                    {
                        id_articulo = c.Int(nullable: false, identity: true),
                        descripcion_articulo = c.String(),
                        existencia = c.Int(nullable: false),
                        id_tipo_inventario = c.Int(nullable: false),
                        costo_unitario = c.Decimal(nullable: false, precision: 18, scale: 2),
                        estado = c.String(),
                    })
                .PrimaryKey(t => t.id_articulo);
            
            CreateTable(
                "dbo.tipo_inventario",
                c => new
                    {
                        id_tipo_inventario = c.Int(nullable: false, identity: true),
                        descripcion_tipo = c.String(),
                        cuenta_contable = c.String(),
                        estado = c.String(),
                    })
                .PrimaryKey(t => t.id_tipo_inventario);
            
            CreateTable(
                "dbo.transaccion",
                c => new
                    {
                        id_transaccion = c.Int(nullable: false, identity: true),
                        tipo_transaccion = c.String(nullable: false),
                        id_articulo = c.Int(nullable: false),
                        cantidad = c.Int(nullable: false),
                        monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id_transaccion);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.transaccion");
            DropTable("dbo.tipo_inventario");
            DropTable("dbo.Articulo");
            DropTable("dbo.almacen");
        }
    }
}
