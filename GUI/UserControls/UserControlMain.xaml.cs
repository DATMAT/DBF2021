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
using BIZ;
using Repository;


namespace GUI
{
    /// <summary>
    /// Interaction logic for UserControlMain.xaml
    /// </summary>
    public partial class UserControlMain : UserControl
    {
        ClassBIZ CB;
        public UserControlMain(ClassBIZ inBIZ)
        {
            InitializeComponent();
            CB = inBIZ;
            ucMainGrid.DataContext = CB;
        }

        //Create new user.
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        // Edit user.
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        // Delete user.
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        // Return book.
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        // Borrow book.
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
