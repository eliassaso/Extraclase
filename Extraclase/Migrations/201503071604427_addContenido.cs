namespace Extraclase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addContenido : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Temas", "Contenido", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Temas", "Contenido");
        }
    }
}
