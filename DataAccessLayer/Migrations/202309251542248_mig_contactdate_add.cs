namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_contactdate_add : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Contacts", "Message", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacts", "Message", c => c.String(maxLength: 100));
            DropColumn("dbo.Contacts", "ContactDate");
        }
    }
}
