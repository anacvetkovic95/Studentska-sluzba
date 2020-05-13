namespace StudentskaSluzba.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ispit",
                c => new
                    {
                        BI = c.Int(nullable: false),
                        PredmetId = c.Int(nullable: false),
                        Ocena = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BI, t.PredmetId })
                .ForeignKey("dbo.Predmet", t => t.PredmetId, cascadeDelete: true)
                .ForeignKey("dbo.Student", t => t.BI, cascadeDelete: true)
                .Index(t => t.BI)
                .Index(t => t.PredmetId);
            
            CreateTable(
                "dbo.Predmet",
                c => new
                    {
                        PredmetId = c.Int(nullable: false, identity: true),
                        NazivPredmeta = c.String(),
                    })
                .PrimaryKey(t => t.PredmetId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        BI = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Prezime = c.String(),
                        Adresa = c.String(),
                        Grad = c.String(),
                    })
                .PrimaryKey(t => t.BI);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ispit", "BI", "dbo.Student");
            DropForeignKey("dbo.Ispit", "PredmetId", "dbo.Predmet");
            DropIndex("dbo.Ispit", new[] { "PredmetId" });
            DropIndex("dbo.Ispit", new[] { "BI" });
            DropTable("dbo.Student");
            DropTable("dbo.Predmet");
            DropTable("dbo.Ispit");
        }
    }
}
