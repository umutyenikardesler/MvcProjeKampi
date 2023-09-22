namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactMessageLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacts", "Message", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Message", c => c.String());
        }
    }
}
