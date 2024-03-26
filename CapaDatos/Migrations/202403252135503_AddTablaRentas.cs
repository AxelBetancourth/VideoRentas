namespace CapaDatos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablaRentas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MRentas",
                c => new
                    {
                        RentaId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        PeliculaId = c.Int(nullable: false),
                        FechaRenta = c.DateTime(nullable: false),
                        FechaRetorno = c.DateTime(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioRenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RentaId)
                .ForeignKey("dbo.MClientes", t => t.ClienteId)
                .ForeignKey("dbo.MPeliculas", t => t.PeliculaId)
                .Index(t => t.ClienteId)
                .Index(t => t.PeliculaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MRentas", "PeliculaId", "dbo.MPeliculas");
            DropForeignKey("dbo.MRentas", "ClienteId", "dbo.MClientes");
            DropIndex("dbo.MRentas", new[] { "PeliculaId" });
            DropIndex("dbo.MRentas", new[] { "ClienteId" });
            DropTable("dbo.MRentas");
        }
    }
}
