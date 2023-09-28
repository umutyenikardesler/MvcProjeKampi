namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somethingChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "WriterMail", c => c.String(maxLength: 50));
            AddColumn("dbo.Admins", "WriterPassword", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Admins", "WriterPassword");
            DropColumn("dbo.Admins", "WriterMail");
        }
    }
}
