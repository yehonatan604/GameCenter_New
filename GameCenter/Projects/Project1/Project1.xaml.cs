using GameCenter.Projects.Project1.Models;
using GameCenter.Projects.Project1.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace GameCenter.Projects.Project1
{
    public partial class Project1 : Window
    {
        User _user;
        List<User> users; 

        public Project1()
        {

            InitializeComponent();
            users = DataHandler.GetUsersList();

            if (users == null || users.Count == 0)
            {
                List<User> initialList = new()
                {
                    new User("Bob", "bob@email.com", "Qaz123!123Qaz"),
                    new User("Sara", "Sara@email.com", "Qaz123!123Qaz"),
                    new User("Neomi", "Neomi@email.com", "Qaz123!123Qaz"),
                    new User("Abed", "Abed@email.com", "Qaz123!123Qaz")
                };
                users = DataHandler.UpdateList(initialList);
            }
            UpdateDataGrid();
        }

        private void UpdateJsonData()
        {
            List<User> tempList = users;
            users = DataHandler.UpdateList(tempList);
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            if (Validate.UserName(Input_UserName))
            {
                users.Add(new User(Input_UserName.Text, Input_Email.Text, "Qaz123!123Qaz"));
                UpdateJsonData();
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
                Input_UserName.Text = ((TextBlock)nameCell.Column.GetCellContent(nameCell.Item)).Text;
                Input_Email.Text = ((TextBlock)emailCell.Column.GetCellContent(emailCell.Item)).Text;
                _user = users.Single(item => item.Id.ToString() == id);
            }
            catch
            {

            }
        }

        private void Btn_Remove_Click(object sender, RoutedEventArgs e)
        {
            users.Remove(_user);
            UpdateJsonData() ;
            UpdateDataGrid();
        }
    }
}
