using System.Collections.Generic;
using System.Linq;
using ToDoListApp.Consts;
using ToDoListApp.Model;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp.Repository
{
    public class ToDoListRepository : IToDoListRepository
    {
        public bool AddToDoList(string toDoName)
        {
            using (var db = new ToDoAppContext())
            {
                var newToDo = new ToDoList
                {
                    Name = toDoName,
                    UserId = SessionInfo.UserId
                };
                db.ToDoLists.Add(newToDo);
                var result = db.SaveChanges();
                return result > 0;
            }
        }

        public List<ToDoList> GetToDoList()
        {
            using (var db = new ToDoAppContext())
            {
                return db.ToDoLists.Where(p => p.UserId == SessionInfo.UserId).ToList();
            }
        }

        public bool RemoveToDoList(int id)
        {
            using (var db = new ToDoAppContext())
            {
                var toDo = new ToDoList { Id = id };
                db.ToDoLists.Attach(toDo);
                db.ToDoLists.Remove(toDo);
                var result = db.SaveChanges();
                return result > 0;
            }
        }
    }
}