using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for FromDownload.xaml
    /// </summary>
    public partial class FromDownload : Window
    {
        public FromDownload(Home frm)
        {
            InitializeComponent();
            _frmHome = frm;
            txtUrl.Text = Url;
             txtPath.Text= Properties.Settings.Default.Path;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Uri uri = new Uri(this.Url);
            FileName = System.IO.Path.GetFileName(uri.AbsolutePath);
            Client.DownloadFileAsync(uri, Properties.Settings.Default.Path + "/" + FileName);
        }

        private void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            Client.CancelAsync();
        }

        private void BtnBrowse_Click(object sender, RoutedEventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog() { Description = "Select your path," })
            {
                if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txtPath.Text = fbd.SelectedPath;
                    Properties.Settings.Default.Path = txtPath.Text;
                    Properties.Settings.Default.Save();
                }
                
            }
        }

        WebClient Client;

        public String Url { get; set; }
        public String FileName { get; set; }
        public double FileSize { get; set; }
        public double Percentage { get; set; }

        private Home _frmHome;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Client = new WebClient();
            Client.DownloadProgressChanged += Client_DownloadProgressChanged;
            Client.DownloadFileCompleted += Client_DownloadFileCompleted;
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            DataBase.FilesRow row = IDMApp.DB.Files.NewFilesRow();
            row.Url = Url;
            row.FileName = FileName;
            row.FileSize = (string.Format("{0:0.##} KB", FileSize / 1024));
            row.DateTime = DateTime.Now;
            IDMApp.DB.Files.AddFilesRow(row);
            IDMApp.DB.AcceptChanges();
            IDMApp.DB.WriteXml(string.Format("{0}/data.dat", System.Windows.Forms.Application.StartupPath));
            System.Windows.Forms.ListViewItem item = new System.Windows.Forms.ListViewItem(row.Id.ToString());
            item.SubItems.Add(row.Url);
            item.SubItems.Add(row.FileName);
            item.SubItems.Add(row.FileSize);
            item.SubItems.Add(row.DateTime.ToLongDateString());
            _frmHome.File_List.Items.Add(item);
            this.Close();

        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressBar.Minimum = 0;
            double receive = double.Parse(e.BytesReceived.ToString());
            FileSize=double.Parse(e.TotalBytesToReceive.ToString());
            Percentage = receive / FileSize * 100;
            lblStatus.Content = $"Downloaded {string.Format("{0:0.##}", Percentage)}";
            ProgressBar.Value = int.Parse(Math.Truncate(Percentage).ToString());
            ProgressBar.UpdateLayout();
        }
    }
}
