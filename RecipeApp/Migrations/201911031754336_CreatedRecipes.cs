namespace RecipeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedRecipes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RecipeName = c.String(),
                        Description = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        Ingredients = c.String(),
                        Servings = c.String(),
                        Time = c.String(),
                        PreparationInstructions = c.String(),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "CreatedBy_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "CreatedBy_Id" });
            DropTable("dbo.Recipes");
        }
    }
}
