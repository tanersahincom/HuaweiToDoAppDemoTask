using System.Linq;
using ToDoListApp.Model;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp.Repository
{
    public class UserRepository : IUserRepository
    {
        public User CheckLogin(string username, string password)
        {
            using (var db = new ToDoAppContext())
            {
                var result = db.Users.FirstOrDefault(p => p.UserName == username && p.Password == password);
                return result;
            }
        }

        public bool RegisterUser(string username, string password)
        {
            using (var db = new ToDoAppContext())
            {
                var user = new User
                {
                    UserName = username,
                    Password = password
                };
                db.Users.Add(user);
                var result = db.SaveChanges();
                return result > 0;
            }
        }
    }
}