using System;
using System.Collections.Generic;
using ToDoListApp.Model;

namespace ToDoListApp.Repository.Interface
{
    internal interface IItemRepository
    {
        bool AddNewItem(Item todoItem);

        List<Item> GetItems(int todoId);

        bool DeleteItem(Item item);

        bool UpdateItemStatus(int itemId, bool check);

        List<Item> FilterItems(string searchText, string selectedItem, DateTime date);
    }
}