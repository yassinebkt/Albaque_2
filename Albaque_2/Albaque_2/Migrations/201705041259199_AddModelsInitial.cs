namespace Albaque_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModelsInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Chiffrages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjetId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        nom = c.String(nullable: false),
                        version = c.String(),
                        Date_Creation = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projets", t => t.ProjetId, cascadeDelete: true)
                .Index(t => t.ProjetId);
            
            CreateTable(
                "dbo.Chiffrage_Tache",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChiffrageId = c.Int(nullable: false),
                        TacheId = c.Int(nullable: false),
                        nom = c.String(nullable: false),
                        ordre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Chiffrages", t => t.ChiffrageId, cascadeDelete: true)
                .ForeignKey("dbo.Taches", t => t.TacheId, cascadeDelete: true)
                .Index(t => t.ChiffrageId)
                .Index(t => t.TacheId);
            
            CreateTable(
                "dbo.Taches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategorieId = c.Int(nullable: false),
                        ComplexiteId = c.Int(nullable: false),
                        TechnologieId = c.Int(nullable: false),
                        nom = c.String(nullable: false),
                        description = c.String(),
                        charge = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .ForeignKey("dbo.Complexites", t => t.ComplexiteId, cascadeDelete: true)
                .ForeignKey("dbo.Technologies", t => t.TechnologieId, cascadeDelete: true)
                .Index(t => t.CategorieId)
                .Index(t => t.ComplexiteId)
                .Index(t => t.TechnologieId);
            
            CreateTable(
                "dbo.Complexites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Nom = c.String(nullable: false),
                        Duree = c.Double(nullable: false),
                        Delai = c.Double(nullable: false),
                        Date_Debut = c.DateTime(nullable: false),
                        Date_Fin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nom = c.String(nullable: false),
                        adresse_Mail = c.String(),
                        numero_Tel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projets", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Chiffrages", "ProjetId", "dbo.Projets");
            DropForeignKey("dbo.Taches", "TechnologieId", "dbo.Technologies");
            DropForeignKey("dbo.Taches", "ComplexiteId", "dbo.Complexites");
            DropForeignKey("dbo.Chiffrage_Tache", "TacheId", "dbo.Taches");
            DropForeignKey("dbo.Taches", "CategorieId", "dbo.Categories");
            DropForeignKey("dbo.Chiffrage_Tache", "ChiffrageId", "dbo.Chiffrages");
            DropIndex("dbo.Projets", new[] { "ClientId" });
            DropIndex("dbo.Taches", new[] { "TechnologieId" });
            DropIndex("dbo.Taches", new[] { "ComplexiteId" });
            DropIndex("dbo.Taches", new[] { "CategorieId" });
            DropIndex("dbo.Chiffrage_Tache", new[] { "TacheId" });
            DropIndex("dbo.Chiffrage_Tache", new[] { "ChiffrageId" });
            DropIndex("dbo.Chiffrages", new[] { "ProjetId" });
            DropTable("dbo.Clients");
            DropTable("dbo.Projets");
            DropTable("dbo.Technologies");
            DropTable("dbo.Complexites");
            DropTable("dbo.Taches");
            DropTable("dbo.Chiffrage_Tache");
            DropTable("dbo.Chiffrages");
            DropTable("dbo.Categories");
        }
    }
}
