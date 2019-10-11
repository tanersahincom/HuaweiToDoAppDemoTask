using System.Windows;
using System.Windows.Controls;
using ToDoListApp.Consts;
using ToDoListApp.Repository;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp
{
    public partial class MainWindow
    {
        private readonly IToDoListRepository _toDoListRepository = new ToDoListRepository();

        public MainWindow()
        {
            InitializeComponent();
            LoadToDoLists();
        }

        private void LoadToDoLists()
        {
            RemoveStackPanelItems();
            var result = _toDoListRepository.GetToDoList();
            foreach (var item in result)
            {
                var newBtn = new Button
                {
                    Content = item.Name,
                    Name = "_" + item.Id
                };
                var margin = newBtn.Margin;
                margin.Top = 5;
                newBtn.Margin = margin;
                newBtn.Click += ToDoButton_Click;
                StackPanel.Children.Add(newBtn);
            }
        }

        private void RemoveStackPanelItems()
        {
            while (StackPanel.Children.Count > 0)
            {
                StackPanel.Children.RemoveAt(StackPanel.Children.Count - 1);
            }
        }

        private void ExitItem_Click(object sender, RoutedEventArgs e)
        {
            var login = new Login();
            login.Show();
            Close();
        }

        private void NewListItem_Click(object sender, RoutedEventArgs e)
        {
            var newList = new NewList();
            if (newList.ShowDialog() != true) return;
            MessageBox.Show(Messages.NewListAdded, "Success",
                MessageBoxButton.OK, MessageBoxImage.Information);
            LoadToDoLists();
        }

        private void ToDoButton_Click(object sender, RoutedEventArgs e)
        {
            var id = int.Parse(((Button)sender).Name.TrimStart('_'));
            var text = ((Button)sender).Content;
            var toDoDetails = new ToDoDetails(id, text.ToString());
            toDoDetails.Show();
            Close();
        }
    }
}