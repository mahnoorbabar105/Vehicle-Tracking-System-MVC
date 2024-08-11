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
    /// Interaction logic for FilterWindow.xaml
    /// </summary>
    public partial class FilterWindow : Window
    {
        ProjectD1Context db = new ProjectD1Context();
        public FilterWindow(List<InOut> myList)
        {
            InitializeComponent();
            mygrid.ItemsSource = myList;
        }
    }
}
