namespace Business.DomainClasses.bhenning.Migrations.DataContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AccountName = c.String(),
                        InceptionDate = c.DateTime(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        CurrentBalance = c.Decimal(nullable: false, storeType: "money"),
                        AccountTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.AccountTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Conditions = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TransactionType = c.Int(nullable: false),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        TransactionDate = c.DateTime(nullable: false),
                        AccountID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Accounts", t => t.AccountID, cascadeDelete: true)
                .Index(t => t.AccountID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "AccountID", "dbo.Accounts");
            DropForeignKey("dbo.Accounts", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "AccountID" });
            DropIndex("dbo.Accounts", new[] { "CustomerID" });
            DropTable("dbo.Transactions");
            DropTable("dbo.AccountTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.Accounts");
        }
    }
}
