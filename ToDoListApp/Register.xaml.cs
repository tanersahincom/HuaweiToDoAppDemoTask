using System.Windows;
using System.Windows.Input;
using ToDoListApp.Consts;
using ToDoListApp.Repository;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp
{
    public partial class Register
    {
        private readonly IUserRepository _userRepository = new UserRepository();

        public Register()
        {
            InitializeComponent();
        }

        private void ButtonMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Login_Clicked(object sender, RoutedEventArgs e)
        {
            NavigateToLogin();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            RegisterUser();
        }

        private void NavigateToLogin()
        {
            var login = new Login();
            login.Show();
            Close();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RegisterUser();
            }
        }

        private void RegisterUser()
        {
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(PasswordText.Password))
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = _userRepository.RegisterUser(UserName.Text, PasswordText.Password);
            if (result)
            {
                NavigateToLogin();
            }
            else
            {
                MessageBox.Show(Messages.SomethingWrong, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}