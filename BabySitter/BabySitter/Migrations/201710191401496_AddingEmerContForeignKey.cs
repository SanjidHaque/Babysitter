namespace BabySitter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmerContForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employers", "EmergencyContact_Id", "dbo.EmergencyContacts");
            DropIndex("dbo.Employers", new[] { "EmergencyContact_Id" });
            RenameColumn(table: "dbo.Employers", name: "EmergencyContact_Id", newName: "EmergencyContactId");
            AlterColumn("dbo.Employers", "EmergencyContactId", c => c.Int(nullable: false));
            CreateIndex("dbo.Employers", "EmergencyContactId");
            AddForeignKey("dbo.Employers", "EmergencyContactId", "dbo.EmergencyContacts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employers", "EmergencyContactId", "dbo.EmergencyContacts");
            DropIndex("dbo.Employers", new[] { "EmergencyContactId" });
            AlterColumn("dbo.Employers", "EmergencyContactId", c => c.Int());
            RenameColumn(table: "dbo.Employers", name: "EmergencyContactId", newName: "EmergencyContact_Id");
            CreateIndex("dbo.Employers", "EmergencyContact_Id");
            AddForeignKey("dbo.Employers", "EmergencyContact_Id", "dbo.EmergencyContacts", "Id");
        }
    }
}
