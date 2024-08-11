using EAD_Project_D1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EAD_Project_D1
{
    public partial class Page1 : Page
    {
        string? selectedValue;
        ProjectD1Context db = new ProjectD1Context();
        public Page1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text != null && password.Text != null)
            {
                string Username = username.Text;
                string Password = password.Text;
                int role = 9;

                if (selectedValue == "Super Admin")
                {
                    role = 0;
                }
                else if (selectedValue == "Admin") 
                {
                    role = 1;
                }
                else if (selectedValue == "Guard")
                {
                    role = 2;
                }
                if (role == 9)
                {
                    MessageBox.Show("Please Select the Item");
                }
                else
                {
                    User temp = new User { Username = username.Text, Password = password.Text, Role = role };

                    db.Users.Add(temp);
                   // db.SaveChanges();
                    MessageBox.Show("New User has been Added");
                    username.Text = "";
                    password.Text = "";
                    yourCombo.SelectedItem = null;
                }
            }
            else
            {
                MessageBox.Show("Please Fill the Textboxes");
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;

            if (selectedItem != null)
            {
                selectedValue = selectedItem.Content.ToString();
            }
            else
            {
                // Handle the case where no item is selected (optional)
                MessageBox.Show("Please Select the Item ");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            UserWindow UW = new UserWindow();
            UW.ShowDialog();
        }

        private void Admin_Click(object sender, RoutedEventArgs e)
        {
            ManagerWindow MW = new ManagerWindow("Admin");
            MW.ShowDialog();

        }
    }
}
    

