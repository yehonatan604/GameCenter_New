using GameCenter.Projects.Project1.Models;
using GameCenter.Projects.Project1.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GameCenter.Projects.Project1
{
    public partial class Project1 : Window
    {
        User _user;
        List<User> users = new List<User> 
            { 
                new User("Bob", "bob@email.com", "Qaz123!123Qaz"),
                new User("Sara", "Sara@email.com", "Qaz123!123Qaz"),
                new User("Neomi", "Neomi@email.com", "Qaz123!123Qaz"),
                new User("Abed", "Abed@email.com", "Qaz123!123Qaz"),
            };
        public Project1()
        {
            InitializeComponent();
            UpdateDataGrid();
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (Validate.UserName(box))
            {
                users.Add(new User(Input_UserName.Text, Input_Email.Text, "Qaz123!123Qaz"));
                UpdateDataGrid();
            }
        }

        private void UpdateDataGrid()
        {
            DataGrid1.ItemsSource = users.ToList();
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var idCell = DataGrid1.SelectedCells[0];
            var nameCell = DataGrid1.SelectedCells[1];
            var emailCell = DataGrid1.SelectedCells[2];

            try
            {
                string id = ((TextBlock)idCell.Column.GetCellContent(idCell.Item)).Text;
                Input_UserName.Text =((TextBlock)nameCell.Column.GetCellContent(nameCell.Item)).Text;
                Input_Email.Text =((TextBlock)emailCell.Column.GetCellContent(emailCell.Item)).Text;
                _user = users.Single(item => item.Id.ToString() == id);
            }
            catch
            {

            }
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            users.Remove(_user);
            UpdateDataGrid();
        }
    }
}
