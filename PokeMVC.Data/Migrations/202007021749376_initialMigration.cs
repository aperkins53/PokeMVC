namespace PokeMVC.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trainer");
            DropTable("dbo.Move");
        }
    }
}
