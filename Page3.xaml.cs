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
    /// <summary>
    /// Interaction logic for Page3.xaml
    /// </summary>
    public partial class Page3 : Page
    {
        ProjectD1Context db = new ProjectD1Context();
        public Page3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(INNumber.Text!= null)
            {
                DateTime currentDateTime = DateTime.Now;
                InOut temp = new InOut { Number = Convert.ToInt32(INNumber.Text), Time = currentDateTime, Inout1 = "IN" };
                db.InOuts.Add(temp);
                db.SaveChanges();
                Vechile? temp2 = db.Vechiles.Where(x => x.Number == Convert.ToInt32(INNumber.Text)).FirstOrDefault();
                if (temp2 != null)
                {
                    MessageBox.Show("New Vechile has been Entered");
                }
                else
                {
                    MessageBox.Show("UnRegistered Vechile");
                }
                INNumber.Text = "";
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (OUTNumber.Text != null)
            {
                DateTime currentDateTime = DateTime.Now;
                InOut temp = new InOut { Number = Convert.ToInt32(OUTNumber.Text), Time = currentDateTime, Inout1 = "OUT" };
                db.InOuts.Add(temp);
                db.SaveChanges();
                Vechile? temp2 = db.Vechiles.Where(x => x.Number == Convert.ToInt32(OUTNumber.Text)).FirstOrDefault();
                if (temp2 != null)
                {
                    MessageBox.Show("New Vechile has been Entered");
                }
                else
                {
                    MessageBox.Show("UnRegistered Vechile");
                }
                OUTNumber.Text = "";
            }
        }
    }
}
