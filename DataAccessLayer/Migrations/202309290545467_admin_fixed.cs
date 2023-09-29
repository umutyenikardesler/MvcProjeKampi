namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin_fixed : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Admins", "WriterMail");
            DropColumn("dbo.Admins", "WriterPassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "WriterPassword", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "WriterMail", c => c.String(maxLength: 50));
        }
    }
}
