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
using EAD_Project_D1.Models;

namespace EAD_Project_D1
{
     
    
    public partial class MainWindow : Window
    {
        UserWindow UW = new UserWindow();
        
        Page1 p1 = new Page1();
        Page2 p2 = new Page2();
        Page3 p3 = new Page3();
        ProjectD1Context db = new ProjectD1Context();
        public MainWindow()
        {
            InitializeComponent();
            username.Text = null;
            password.Text = null;
            myFrame.Content = p2;
            //  UW.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (username.Text != "" && password.Text != "")
            {
                string Username = username.Text;
                string Password = password.Text;
                User? temp = db.Users.Where(x => x.Username == Username && x.Password == Password).FirstOrDefault();
                if (temp != null)
                {
                    if (temp.Role == 0)
                    {
                        myFrame.Content = p1;
                    }
                    else if (temp.Role == 1)
                    {
                        myFrame.Content = p2;
                    }
                    else if (temp.Role == 2)
                    {
                        myFrame.Content = p3;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid User endered");
                }
            }
            else
            {
                MessageBox.Show("Please Fill the TextBoxes");
            }

        }
    }
}
