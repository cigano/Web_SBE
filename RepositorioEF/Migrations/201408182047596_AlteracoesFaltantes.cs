namespace RepositorioEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlteracoesFaltantes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SBE_ST_Curso", "Local", c => c.String(maxLength: 90));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SBE_ST_Curso", "Local", c => c.String(nullable: false, maxLength: 90));
        }
    }
}
