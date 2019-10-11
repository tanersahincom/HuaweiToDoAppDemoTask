using System.Windows;
using System.Windows.Input;
using ToDoListApp.Consts;
using ToDoListApp.Repository;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp
{
    public partial class NewList
    {
        private readonly IToDoListRepository _toDoRepository = new ToDoListRepository();

        public NewList()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            AddNewList();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                AddNewList();
            }
        }

        private void AddNewList()
        {
            if (string.IsNullOrEmpty(ToDoName.Text))
            {
                MessageBox.Show(Messages.MissingInfo, "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
                return;
            }
            var result = _toDoRepository.AddToDoList(ToDoName.Text);
            DialogResult = result;
        }
    }
}