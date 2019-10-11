using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Documents;
using ToDoListApp.Model;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp.Repository
{
    public class ItemRepository : IItemRepository
    {
        public bool AddNewItem(Item todoItem)
        {
            using (var db = new ToDoAppContext())
            {
                db.Items.Add(todoItem);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        public List<Item> GetItems(int todoId)
        {
            using (var db = new ToDoAppContext())
            {
                var result = db.Items.Where(p => p.ToDoListId == todoId).ToList();
                return result;
            }
        }

        public bool DeleteItem(Item item)
        {
            using (var db = new ToDoAppContext())
            {
                db.Items.Attach(item);
                db.Entry(item).State = EntityState.Deleted;
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        public bool UpdateItemStatus(int itemId, bool check)
        {
            using (var db = new ToDoAppContext())
            {
                var item = db.Items.FirstOrDefault(p => p.Id == itemId);
                item.Status = check;
                db.Items.Attach(item);
                db.Entry(item).State = EntityState.Modified;
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        public List<Item> FilterItems(string searchText, string selectedItem, DateTime date)
        {
            using (var db = new ToDoAppContext())
            {
                List<Item> items;
                if (selectedItem == "All")
                {
                    items = db.Items.Where(p => p.Name.Contains(searchText)
                                               && p.DeadLine <= date).ToList();
                }
                else
                {
                    var isActive = selectedItem == "Active";
                    items = db.Items.Where(z => z.Name.Contains(searchText)
                                                && z.Status == isActive && z.DeadLine <= date).ToList();
                }
                return items;
            }
        }
    }
}