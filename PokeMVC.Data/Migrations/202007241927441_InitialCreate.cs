namespace PokeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pokemon",
                c => new
                    {
                        PokemonId = c.Int(nullable: false, identity: true),
                        PokedexNumber = c.Int(nullable: false),
                        Species = c.String(nullable: false),
                        Level = c.Int(nullable: false),
                        PrimaryType = c.String(nullable: false),
                        SecondaryType = c.String(),
                        EvoCondition = c.String(),
                        OriginalRegion = c.String(nullable: false),
                        IsLegendary = c.Boolean(nullable: false),
                        IsMythical = c.Boolean(nullable: false),
                        Trainer_TrainerId = c.Int(),
                    })
                .PrimaryKey(t => t.PokemonId)
                .ForeignKey("dbo.Trainer", t => t.Trainer_TrainerId)
                .Index(t => t.Trainer_TrainerId);
            
            CreateTable(
                "dbo.Move",
                c => new
                    {
                        MoveId = c.Int(nullable: false, identity: true),
                        MoveName = c.String(nullable: false),
                        MovePower = c.Int(nullable: false),
                        MoveAccuracy = c.Int(nullable: false),
                        MovePP = c.Int(nullable: false),
                        ExtraEffect = c.String(),
                    })
                .PrimaryKey(t => t.MoveId);
            
            CreateTable(
                "dbo.PokemonMove",
                c => new
                    {
                        PokemonMoveId = c.Int(nullable: false, identity: true),
                        PokemonId = c.Int(nullable: false),
                        MoveId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PokemonMoveId)
                .ForeignKey("dbo.Move", t => t.MoveId, cascadeDelete: true)
                .ForeignKey("dbo.Pokemon", t => t.PokemonId, cascadeDelete: true)
                .Index(t => t.PokemonId)
                .Index(t => t.MoveId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Trainer",
                c => new
                    {
                        TrainerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsGymLeader = c.Boolean(nullable: false),
                        IsEliteFour = c.Boolean(nullable: false),
                        IsChampion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TrainerId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Pokemon", "Trainer_TrainerId", "dbo.Trainer");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PokemonMove", "PokemonId", "dbo.Pokemon");
            DropForeignKey("dbo.PokemonMove", "MoveId", "dbo.Move");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.PokemonMove", new[] { "MoveId" });
            DropIndex("dbo.PokemonMove", new[] { "PokemonId" });
            DropIndex("dbo.Pokemon", new[] { "Trainer_TrainerId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Trainer");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.PokemonMove");
            DropTable("dbo.Move");
            DropTable("dbo.Pokemon");
        }
    }
}
