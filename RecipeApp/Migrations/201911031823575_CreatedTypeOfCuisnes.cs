namespace RecipeApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedTypeOfCuisnes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TypeOfCuisines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CuisineName = c.String(),
                        CuisineDescription = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TypeOfCuisines");
        }
    }
}
