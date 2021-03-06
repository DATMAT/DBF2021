﻿using System;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassBIZ CB;
        ClassLogin CL;
        UserControlLogin UCL;
        UserControlMain UCM;

        public MainWindow()
        {
            InitializeComponent();
            CB = new ClassBIZ();
            CL = new ClassLogin();
            UCL = new UserControlLogin(CL,CB, MainFormGrid);
            UCM = new UserControlMain(CB);

            MainFormGrid.Children.Add(UCM);
            MainFormGrid.Children.Add(UCL);
        }
    }
}
