namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixMapTableColumnClassProperty : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Product", "price", c => c.Decimal(storeType: "money"));
            AlterColumn("dbo.orderproduct", "price", c => c.Decimal(storeType: "money"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.orderproduct", "price", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Product", "price", c => c.Decimal(precision: 18, scale: 2));
        }
    }
}
