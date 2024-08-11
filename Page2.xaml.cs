using EAD_Project_D1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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

    public partial class Page2 : Page
    {
        ProjectD1Context db = new ProjectD1Context();
        VechileWindow VW = new VechileWindow();
        public Page2()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Driver.Text != null && BusNumber.Text != null && Buses.SelectedItem != null)
            {
                string Username = Driver.Text;
                string Password = BusNumber.Text;
                ComboBoxItem selectedItem = (ComboBoxItem)Buses.SelectedItem;


                string? selectedValue = selectedItem.Content.ToString();





                Vechile temp = new Vechile { Divername=Driver.Text, Number = Convert.ToInt32(BusNumber.Text), Type =selectedValue };

                db.Vechiles.Add(temp);
                db.SaveChanges();
                MessageBox.Show("New Vechile has been Added");
                Driver.Text = "";
                BusNumber.Text = "";
                Buses.SelectedItem = null;
            }

            else
            {
                MessageBox.Show("Please Fill the Textboxes");
            }
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            InOut objOut;
            InOut objIN;
            int BusNo = Convert.ToInt32(StatusT1.Text);
            objOut = db.InOuts.Where(x => x.Number == BusNo && x.Inout1 == "OUT").Last();
            objIN = db.InOuts.Where(x => x.Number == BusNo && x.Inout1 == "IN").Last();
            DateTime currenttime = DateTime.Now;
            if (objOut != null && objIN!=null)
            {
                if (currenttime.Day == objIN.Time.Day)
                {
                    if (objOut.Time.Day < currenttime.Day)
                    {
                        MessageBox.Show("Vechile is IN");
                        

                    }
                    else if (objOut.Time > objIN.Time)
                    {
                        //Bus is out
                        MessageBox.Show("Vechile is OUT");
                    }
                    else if (objOut.Time < objIN.Time)
                    {
                        //Bus is in
                        MessageBox.Show("Vechile is IN");
                    }
                }
                else
                {
                    if (objIN.Time < objOut.Time)
                    {
                        //Bus is out
                        MessageBox.Show("Vechile is OUT");
                    }
                    else
                    {
                        //Bus is IN
                        MessageBox.Show("Vechile is IN");
                    }
                }
            }else if(objIN != null && objOut ==null )
            {
                //Bus is in 
                MessageBox.Show("Vechile is IN");
            }
            else
            {
                //bus out
                MessageBox.Show("Vechile is OUT");
            }
            StatusT1.Text = null;
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            string From = from.Text;
            string To = to.Text;
            if (From != "" && To != "")
            {
                if (From[2] == '/' && To[2] == '/' && From[5] == '/' && To[5] == '/')
                {
                    List<InOut> myList = new List<InOut>();

                    DateTime fromparsedDate;
                    DateTime toparsedDate;

                    // Parse the string using TryParseExact for safe conversion
                    DateTime.TryParseExact(From, "MM/dd/yyyy", null, DateTimeStyles.None, out fromparsedDate);
                    DateTime.TryParseExact(To, "MM/dd/yyyy", null, DateTimeStyles.None, out toparsedDate);
                    if (myList != null)
                    {
                        myList = db.InOuts.Where(x => x.Time.Date >= fromparsedDate && x.Time.Date <= toparsedDate).ToList();
                        FilterWindow FW = new FilterWindow(myList);
                        FW.ShowDialog();
                        from.Text = null;
                        to.Text = null;
                    }else
                    {
                        MessageBox.Show("Report does not Exit");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter the Dates In MM/DD/YYYY Format");
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Dates First");
            }





        }

        private void ManageVechile_Click(object sender, RoutedEventArgs e)
        {
            VW.ShowDialog();
        }
    }

}
