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
using System.Windows.Shapes;

namespace MarkEdPlace
{
    /// <summary>
    /// Interaction logic for AlertWindow.xaml
    /// </summary>
    public partial class AlertWindow : Window
    {
        public AlertWindow(string alertMessage)
        {
            InitializeComponent();
            AlertMessage.Text = alertMessage;
        }

        private void CloseAlert(object sender, RoutedEventArgs e) => Close();
    }
}
