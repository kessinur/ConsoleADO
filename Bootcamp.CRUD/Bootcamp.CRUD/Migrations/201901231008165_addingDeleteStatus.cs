namespace Bootcamp.CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingDeleteStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "CreateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Suppliers", "UpdateDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Suppliers", "DeleteDate", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Suppliers", "IsDelete", c => c.Boolean(nullable: false));
            DropColumn("dbo.Suppliers", "CreateData");
            DropColumn("dbo.Suppliers", "UpdateData");
            DropColumn("dbo.Suppliers", "DeleteData");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Suppliers", "DeleteData", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Suppliers", "UpdateData", c => c.DateTimeOffset(nullable: false, precision: 7));
            AddColumn("dbo.Suppliers", "CreateData", c => c.DateTimeOffset(nullable: false, precision: 7));
            DropColumn("dbo.Suppliers", "IsDelete");
            DropColumn("dbo.Suppliers", "DeleteDate");
            DropColumn("dbo.Suppliers", "UpdateDate");
            DropColumn("dbo.Suppliers", "CreateDate");
        }
    }
}
