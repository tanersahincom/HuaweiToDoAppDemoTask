using System.Collections.Generic;
using ToDoListApp.Model;

namespace ToDoListApp.Repository.Interface
{
    internal interface IToDoListRepository
    {
        bool AddToDoList(string toDoName);

        List<ToDoList> GetToDoList();

        bool RemoveToDoList(int id);
    }
}