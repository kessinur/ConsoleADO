namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingModelFirst : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        JoinDate = c.DateTimeOffset(nullable: false, precision: 7),
                        CreateData = c.DateTimeOffset(nullable: false, precision: 7),
                        UpdateData = c.DateTimeOffset(nullable: false, precision: 7),
                        DeleteData = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Suppliers");
        }
    }
}
