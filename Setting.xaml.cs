using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IDM
{
    /// <summary>
    /// Interaction logic for Setting.xaml
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog fbd=new FolderBrowserDialog() { Description="Select your path," })
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    txtPath.Text = fbd.SelectedPath;
            }
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                Properties.Settings.Default.Path = txtPath.Text;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Please select your path.",
                                               "Message",
                                               MessageBoxButton.OK,
                                               MessageBoxImage.Information);
            }
        }
    }
}
