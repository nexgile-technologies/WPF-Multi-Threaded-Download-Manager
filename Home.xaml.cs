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

namespace IDM
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }
        private void Url_Click(object sender, RoutedEventArgs e)
        {
            AddUrl AddUrl = new AddUrl();
         AddUrl.ShowDialog();
            if (!string.IsNullOrWhiteSpace(AddUrl.Url))
            {
                FromDownload frmDownload = new FromDownload(this);
                frmDownload.Url = AddUrl.Url;
                frmDownload.Show();

            }
        }
       
             private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Setting Setting = new Setting();
            Setting.Show();
        }
    }
}
