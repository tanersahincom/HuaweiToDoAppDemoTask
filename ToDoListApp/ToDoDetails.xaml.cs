using System;
using System.Windows;
using System.Windows.Controls;
using ToDoListApp.Consts;
using ToDoListApp.Model;
using ToDoListApp.Repository;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp
{
    public partial class ToDoDetails
    {
        private readonly IToDoListRepository _toDoListRepository = new ToDoListRepository();
        private readonly IItemRepository _itemRepository = new ItemRepository();
        private readonly int _id;

        public ToDoDetails(int id, string text)
        {
            InitializeComponent();
            _id = id;
            TodoName.Content = text;
            LoadToDoItems();
            DatePicker.Text = DateTime.Now.ToShortDateString();
        }

        public void LoadToDoItems()
        {
            var result = _itemRepository.GetItems(_id);
            ToDoListView.ItemsSource = result;
        }

        private void NavigateToMainPage()
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void ListRemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show(Messages.ListRemove, "Remove List",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result != MessageBoxResult.Yes) return;
            _toDoListRepository.RemoveToDoList(_id);
            NavigateToMainPage();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigateToMainPage();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            var newListItem = new NewListItem(_id);
            if (newListItem.ShowDialog() != true) return;
            LoadToDoItems();
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = ToDoListView.SelectedItem;
            if (selectedItem != null)
            {
                var selectedToDoItem = (Item)selectedItem;
                var result = _itemRepository.DeleteItem(selectedToDoItem);
                if (result)
                {
                    MessageBox.Show(Messages.ItemRemoved, "Success",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    LoadToDoItems();
                }
                else
                {
                    MessageBox.Show(Messages.SomethingWrong, "Fail",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show(Messages.ChooseItem, "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void StatusCheckBox_OnClick(object sender, RoutedEventArgs e)
        {
            var checkbox = (CheckBox)sender;
            var id = int.Parse(checkbox.Content.ToString());
            _itemRepository.UpdateItemStatus(id, checkbox.IsChecked.Value);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var date = DateTime.Parse(DatePicker.Text);
            var result = _itemRepository.FilterItems(SearchText.Text, Status.Text, date);
            ToDoListView.ItemsSource = result;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SearchText.Text = "";
            Status.SelectedIndex = 0;
            LoadToDoItems();
        }
    }
}