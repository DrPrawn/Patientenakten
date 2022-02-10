using System;
using System.IO;
using System.Text;
using System.Windows;

namespace Patientenakten
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

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string fileName = textBoxFileName.Text;

            using (FileStream fs = File.Create(fileName))
            {
                byte[] contentConvert = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvert, 0, contentConvert.Length);
            }

        }
    }
}
