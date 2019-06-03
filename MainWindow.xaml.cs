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
using IDM.UI;

namespace IDM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NewDownload_Click(object sender, RoutedEventArgs e)
        {
            NewDownLoad NewDownloadWindow = new NewDownLoad();
            NewDownloadWindow.Show();

        }
        
        private void NewVideoDownload_Click(object sender, RoutedEventArgs e)
        {
            NewVideoDownload NewVideoDownloadWindow = new NewVideoDownload();
            NewVideoDownloadWindow.Show();
        }
    }
}
