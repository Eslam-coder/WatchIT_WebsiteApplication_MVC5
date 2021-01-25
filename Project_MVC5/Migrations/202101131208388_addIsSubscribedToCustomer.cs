namespace Project_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIsSubscribedToCustomer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SignUpFee = c.Short(nullable: false),
                        DurationInMonth = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Customers", "IsSubscribedToNewsLetter", c => c.Boolean(nullable: false));
            AddColumn("dbo.Customers", "MembershipTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropColumn("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.Customers", "IsSubscribedToNewsLetter");
            DropTable("dbo.MembershipTypes");
        }
    }
}
