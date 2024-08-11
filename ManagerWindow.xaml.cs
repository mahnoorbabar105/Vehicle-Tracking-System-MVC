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
    /// Interaction logic for ManagerWindow.xaml
    /// </summary>
    public partial class ManagerWindow : Window
    {
        Page1 P1 = new Page1();
        Page2 P2 = new Page2();
        Page3 P3 = new Page3();
        public ManagerWindow(string value)
        {
            InitializeComponent();
            if (value == "Admin")
            {
                myframe.Content = P2;
            }else if (value == "Guard")
            {
                myframe.Content = P3;
            }
        }
    }
}
