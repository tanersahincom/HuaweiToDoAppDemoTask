using System;
using System.Windows;
using ToDoListApp.Consts;
using ToDoListApp.Model;
using ToDoListApp.Repository;
using ToDoListApp.Repository.Interface;

namespace ToDoListApp
{
    public partial class NewListItem
    {
        private readonly IItemRepository _itemRepository = new ItemRepository();
        private readonly int _toDoId;

        public NewListItem(int toDoId)
        {
            InitializeComponent();
            _toDoId = toDoId;
            DeadLine.Text = DateTime.Now.ToShortDateString();
        }

        private void ButtonAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Description.Text) || string.IsNullOrEmpty(Name.Text) ||
                string.IsNullOrEmpty(DeadLine.Text))
            {
                MessageBox.Show(Messages.MissingInfo, "Fail",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var result = _itemRepository.AddNewItem(new Item
            {
                DeadLine = DateTime.Parse(DeadLine.Text),
                Description = Description.Text,
                Name = Name.Text,
                Status = Status.IsChecked.Value,
                ToDoListId = _toDoId
            });
            if (result)
            {
                DialogResult = true;
                MessageBox.Show(Messages.NewListItemAdded, "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
            else
            {
                MessageBox.Show(Messages.SomethingWrong, "Fail",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                DialogResult = false;
            }
        }
    }
}