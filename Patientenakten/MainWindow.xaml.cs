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
        public const string DIR_PATH = @"C:\Users\abcd\Desktop\test\";
        public const string FILE_EXT = ".txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string fileName = textBoxFileName.Text;

            using (FileStream fs = File.Create(DIR_PATH + fileName + FILE_EXT))
            {
                byte[] contentConvert = Encoding.ASCII.GetBytes(content);
                fs.Write(contentConvert, 0, contentConvert.Length);
            }
            MessageBox.Show("Datei wurde angelegt");
        }

        private void BtnOpen_Click(object sender, RoutedEventArgs e)
        {
            string fileName = textBoxFileName.Text;

            using (FileStream fs = File.OpenRead(DIR_PATH + fileName + FILE_EXT))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content;
                }
            }
        }
    }
}