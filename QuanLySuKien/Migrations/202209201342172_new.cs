namespace QuanLySuKien.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        idCategory = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idCategory);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        idEvent = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        content = c.String(),
                        status = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        image = c.String(maxLength: 255),
                        participant = c.String(maxLength: 255),
                        idUser = c.Int(nullable: false),
                        idGuest = c.Int(nullable: false),
                        idCategory = c.Int(nullable: false),
                        idOrganiser = c.Int(nullable: false),
                        idCooperative = c.Int(nullable: false),
                        Event_idEvent = c.Int(),
                    })
                .PrimaryKey(t => t.idEvent)
                .ForeignKey("dbo.Categories", t => t.idCategory)
                .ForeignKey("dbo.Cooperatives", t => t.idCooperative)
                .ForeignKey("dbo.Events", t => t.Event_idEvent)
                .ForeignKey("dbo.Guests", t => t.idGuest)
                .ForeignKey("dbo.Organisers", t => t.idOrganiser)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idUser)
                .Index(t => t.idGuest)
                .Index(t => t.idCategory)
                .Index(t => t.idOrganiser)
                .Index(t => t.idCooperative)
                .Index(t => t.Event_idEvent);
            
            CreateTable(
                "dbo.Cooperatives",
                c => new
                    {
                        idCooperative = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idCooperative);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        idGuest = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idGuest);
            
            CreateTable(
                "dbo.Organisers",
                c => new
                    {
                        idOrganiser = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idOrganiser);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        idUser = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false, maxLength: 255),
                        password = c.String(nullable: false, maxLength: 255),
                        role = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idUser);
            
            CreateTable(
                "dbo.Information",
                c => new
                    {
                        idInformation = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        phoneNumber = c.String(maxLength: 255),
                        idPosition = c.Int(nullable: false),
                        idUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idInformation)
                .ForeignKey("dbo.Positions", t => t.idPosition)
                .ForeignKey("dbo.Users", t => t.idUser)
                .Index(t => t.idPosition)
                .Index(t => t.idUser);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        idPosition = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.idPosition);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Information", "idUser", "dbo.Users");
            DropForeignKey("dbo.Information", "idPosition", "dbo.Positions");
            DropForeignKey("dbo.Events", "idUser", "dbo.Users");
            DropForeignKey("dbo.Events", "idOrganiser", "dbo.Organisers");
            DropForeignKey("dbo.Events", "idGuest", "dbo.Guests");
            DropForeignKey("dbo.Events", "Event_idEvent", "dbo.Events");
            DropForeignKey("dbo.Events", "idCooperative", "dbo.Cooperatives");
            DropForeignKey("dbo.Events", "idCategory", "dbo.Categories");
            DropIndex("dbo.Information", new[] { "idUser" });
            DropIndex("dbo.Information", new[] { "idPosition" });
            DropIndex("dbo.Events", new[] { "Event_idEvent" });
            DropIndex("dbo.Events", new[] { "idCooperative" });
            DropIndex("dbo.Events", new[] { "idOrganiser" });
            DropIndex("dbo.Events", new[] { "idCategory" });
            DropIndex("dbo.Events", new[] { "idGuest" });
            DropIndex("dbo.Events", new[] { "idUser" });
            DropTable("dbo.Positions");
            DropTable("dbo.Information");
            DropTable("dbo.Users");
            DropTable("dbo.Organisers");
            DropTable("dbo.Guests");
            DropTable("dbo.Cooperatives");
            DropTable("dbo.Events");
            DropTable("dbo.Categories");
        }
    }
}
