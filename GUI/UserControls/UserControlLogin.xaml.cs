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
    /// Interaction logic for UserControlLogin.xaml
    /// </summary>
    public partial class UserControlLogin : UserControl
    {
        ClassLogin CL;
        ClassBIZ CB;
        Grid inGrid;
        public UserControlLogin(ClassLogin inCL, ClassBIZ inBIZ, Grid tGrid)
        {
            InitializeComponent();
            CL = inCL;
            CB = inBIZ;
            GridLogin.DataContext = CL;
            inGrid = tGrid;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ClassPerson logPerson = CL.GetUserData();

            if (logPerson.id > 0 && logPerson != null)
            {
                CB.person = logPerson;

                inGrid.Children.Remove(this);
            }
        }
    }
}
