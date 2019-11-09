namespace RecipeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTypeOfCuisinesToRecipes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Cuisine_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "Cuisine_Id");
            AddForeignKey("dbo.Recipes", "Cuisine_Id", "dbo.TypeOfCuisines", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Cuisine_Id", "dbo.TypeOfCuisines");
            DropIndex("dbo.Recipes", new[] { "Cuisine_Id" });
            DropColumn("dbo.Recipes", "Cuisine_Id");
        }
    }
}
