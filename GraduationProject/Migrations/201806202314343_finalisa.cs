namespace GraduationProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finalisa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "TU_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Events", "Talenteduser_Id", c => c.Int());
            AddColumn("dbo.Experiences", "TU_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Experiences", "Talenteduser_Id", c => c.Int());
            AddColumn("dbo.Workshops", "TU_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Workshops", "Talenteduser_Id", c => c.Int());
            CreateIndex("dbo.Events", "Talenteduser_Id");
            CreateIndex("dbo.Experiences", "Talenteduser_Id");
            CreateIndex("dbo.Workshops", "Talenteduser_Id");
            AddForeignKey("dbo.Events", "Talenteduser_Id", "dbo.TalentedUsers", "Id");
            AddForeignKey("dbo.Experiences", "Talenteduser_Id", "dbo.TalentedUsers", "Id");
            AddForeignKey("dbo.Workshops", "Talenteduser_Id", "dbo.TalentedUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Workshops", "Talenteduser_Id", "dbo.TalentedUsers");
            DropForeignKey("dbo.Experiences", "Talenteduser_Id", "dbo.TalentedUsers");
            DropForeignKey("dbo.Events", "Talenteduser_Id", "dbo.TalentedUsers");
            DropIndex("dbo.Workshops", new[] { "Talenteduser_Id" });
            DropIndex("dbo.Experiences", new[] { "Talenteduser_Id" });
            DropIndex("dbo.Events", new[] { "Talenteduser_Id" });
            DropColumn("dbo.Workshops", "Talenteduser_Id");
            DropColumn("dbo.Workshops", "TU_Id");
            DropColumn("dbo.Experiences", "Talenteduser_Id");
            DropColumn("dbo.Experiences", "TU_Id");
            DropColumn("dbo.Events", "Talenteduser_Id");
            DropColumn("dbo.Events", "TU_Id");
        }
    }
}
