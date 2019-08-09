namespace ProyectoInventario.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class transaccion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.transaccion", "fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.transaccion", "fecha");
        }
    }
}
