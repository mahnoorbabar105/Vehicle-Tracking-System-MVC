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
    /// Interaction logic for VechileWindow.xaml
    /// </summary>
    public partial class VechileWindow : Window
    {
        ProjectD1Context db = new ProjectD1Context();
        int id1;
        Vechile obj;
        public VechileWindow()
        {
            InitializeComponent();

            mygrid.ItemsSource = db.Vechiles.ToList();
        }
        private void delete(object sender, RoutedEventArgs e)
        {
            if (mygrid.SelectedItem != null)
            {
                int id = (mygrid.SelectedItem as Vechile).Id;
                Vechile? u = db.Vechiles.Where(x => x.Id == id).First();
                db.Vechiles.Remove(u);
                db.SaveChanges();
                mygrid.ItemsSource = db.Vechiles.ToList();
            }
        }
        private void edit(object sender, RoutedEventArgs e)
        {
            
                id1 = (mygrid.SelectedItem as Vechile).Id;
                obj = db.Vechiles.Where(x => x.Id == id1).First();
                t3.Text = obj.Divername;
                t1.Text = Convert.ToString(obj.Number);
                t2.Text = obj.Type;
            

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (t1.Text != null && t2.Text != null)
            {
                obj.Divername = t3.Text;
                obj.Number= Convert.ToInt32(t1.Text);
                if (t2.Text == "Bus" || t2.Text == "Car" || t2.Text == "Small Bus" || t2.Text == "Bike")
                {
                    obj.Type = t2.Text;
                     db.SaveChanges();
                    mygrid.ItemsSource = db.Vechiles.ToList();
                    t1.Text = null;
                    t2.Text = null;
                    t3.Text = null;
                    mygrid.SelectedItem = null;
                }
                else
                {
                    MessageBox.Show("Type cam only be Bus, Small Bus, Car and Bike");
                }

            }
            else
            {
                MessageBox.Show("TexBoxes cannot be Empty");
            }


        }
    }
}
