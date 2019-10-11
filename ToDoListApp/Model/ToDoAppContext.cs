using System.Data.Entity;

namespace ToDoListApp.Model
{
    internal class ToDoAppContext : DbContext
    {
        public ToDoAppContext() : base("ToDoAppContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}