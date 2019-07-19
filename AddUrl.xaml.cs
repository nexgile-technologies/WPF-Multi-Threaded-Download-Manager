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

namespace IDM
{
    /// <summary>
    /// Interaction logic for AddUrl.xaml
    /// </summary>
    public partial class AddUrl : Window
    {
        public AddUrl()
        {
            InitializeComponent();
        }

        public string Url { get; set; }
        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Url = txtURL.Text;
            this.Close();
        }
    }
}
