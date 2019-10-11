using System.Windows;
using System.Windows.Input;
using ToDoListApp.Consts;
using ToDoListApp.Repository;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp
{
    public partial class Login
    {
        private readonly IUserRepository _userRepository = new UserRepository();

        public Login()
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

        private void Register_Clicked(object sender, RoutedEventArgs e)
        {
            var register = new Register();
            register.Show();
            Close();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LoginUser();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginUser();
            }
        }

        private void LoginUser()
        {
            if (string.IsNullOrEmpty(UserName.Text) || string.IsNullOrEmpty(PasswordText.Password))
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = _userRepository.CheckLogin(UserName.Text, PasswordText.Password);
            if (result != null)
            {
                SessionInfo.UserId = result.Id;
                var mainPage = new MainWindow();
                mainPage.Show();
                Close();
            }
            else
            {
                MessageBox.Show(Messages.WrongLogin, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                ClearFields();
            }
        }

        private void ClearFields()
        {
            UserName.Text = "";
            PasswordText.Password = "";
        }
    }
}