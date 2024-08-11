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
using System.Windows.Shapes;

namespace EAD_Project_D1
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        ProjectD1Context db = new ProjectD1Context();
        int id1;
        User? obj;
        public UserWindow()
        {
            InitializeComponent();
            mygrid.ItemsSource = db.Users.ToList();
            
        }
        private void delete(object sender, RoutedEventArgs e)
        {
            if (mygrid.SelectedItem!=null) {
                int id = (mygrid.SelectedItem as User).Id;
                User? u = db.Users.Where(x => x.Id == id).First();
                db.Users.Remove(u);
                db.SaveChanges();
                mygrid.ItemsSource = db.Users.ToList();
            }
        }

        private void edit(object sender, RoutedEventArgs e)
        {
            if ((mygrid.SelectedItem as User) != null)
            {
                id1 = (mygrid.SelectedItem as User).Id;
                obj = db.Users.Where(x => x.Id == id1).First();
                t1.Text =obj.Username;
                t2.Text = obj.Password;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                if (t1.Text != null && t2.Text != null)
                {
                    obj.Username = t1.Text;
                    obj.Password = t2.Text;
                    db.SaveChanges();
                    mygrid.ItemsSource = db.Users.ToList();
                    t1.Text = null;
                    t2.Text = null;
                    mygrid.SelectedItem = null;

                }
                else
                {
                    MessageBox.Show("TexBoxes cannot be Empty");
                }

            
        }
    }
}
