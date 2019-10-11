namespace ToDoListApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class server : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "ToDoList_Id", "dbo.ToDoLists");
            DropForeignKey("dbo.ToDoLists", "UserId", "dbo.Users");
            DropIndex("dbo.Items", new[] { "ToDoList_Id" });
            DropIndex("dbo.ToDoLists", new[] { "UserId" });
            AddColumn("dbo.Items", "ToDoListId", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "ToDoList_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "ToDoList_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Items", "ToDoListId");
            CreateIndex("dbo.ToDoLists", "UserId");
            CreateIndex("dbo.Items", "ToDoList_Id");
            AddForeignKey("dbo.ToDoLists", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Items", "ToDoList_Id", "dbo.ToDoLists", "Id", cascadeDelete: true);
        }
    }
}
