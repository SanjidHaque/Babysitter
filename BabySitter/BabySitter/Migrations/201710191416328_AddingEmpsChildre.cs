namespace BabySitter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmpsChildre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Children", "EmployerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Children", "EmployerId");
            AddForeignKey("dbo.Children", "EmployerId", "dbo.Employers", "Id", cascadeDelete: true);
            DropColumn("dbo.Employers", "ChildNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employers", "ChildNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.Children", "EmployerId", "dbo.Employers");
            DropIndex("dbo.Children", new[] { "EmployerId" });
            DropColumn("dbo.Children", "EmployerId");
        }
    }
}
