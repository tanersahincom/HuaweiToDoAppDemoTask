using ToDoListApp.Model;

namespace ToDoListApp.Repository.Interface
{
    public interface IUserRepository
    {
        User CheckLogin(string username, string password);

        bool RegisterUser(string username, string password);
    }
}