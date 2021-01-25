namespace Project_MVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addBirthDateToCustomer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "BirthDate");
        }
    }
}
