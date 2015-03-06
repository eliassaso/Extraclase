namespace Extraclase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyThemes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Temas", "IdList_DataGroupField", c => c.String());
            AddColumn("dbo.Temas", "IdList_DataTextField", c => c.String());
            AddColumn("dbo.Temas", "IdList_DataValueField", c => c.String());
            AddColumn("dbo.Temas", "MateriaList_DataGroupField", c => c.String());
            AddColumn("dbo.Temas", "MateriaList_DataTextField", c => c.String());
            AddColumn("dbo.Temas", "MateriaList_DataValueField", c => c.String());
            AddColumn("dbo.Temas", "GradoList_DataGroupField", c => c.String());
            AddColumn("dbo.Temas", "GradoList_DataTextField", c => c.String());
            AddColumn("dbo.Temas", "GradoList_DataValueField", c => c.String());
            AddColumn("dbo.Temas", "EmployeeList_DataGroupField", c => c.String());
            AddColumn("dbo.Temas", "EmployeeList_DataTextField", c => c.String());
            AddColumn("dbo.Temas", "EmployeeList_DataValueField", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Temas", "EmployeeList_DataValueField");
            DropColumn("dbo.Temas", "EmployeeList_DataTextField");
            DropColumn("dbo.Temas", "EmployeeList_DataGroupField");
            DropColumn("dbo.Temas", "GradoList_DataValueField");
            DropColumn("dbo.Temas", "GradoList_DataTextField");
            DropColumn("dbo.Temas", "GradoList_DataGroupField");
            DropColumn("dbo.Temas", "MateriaList_DataValueField");
            DropColumn("dbo.Temas", "MateriaList_DataTextField");
            DropColumn("dbo.Temas", "MateriaList_DataGroupField");
            DropColumn("dbo.Temas", "IdList_DataValueField");
            DropColumn("dbo.Temas", "IdList_DataTextField");
            DropColumn("dbo.Temas", "IdList_DataGroupField");
        }
    }
}
