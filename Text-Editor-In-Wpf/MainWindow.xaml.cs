using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Text_Editor_In_Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string FileName { get; set; }

        SolidColorBrush Off = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        SolidColorBrush On = new SolidColorBrush(Color.FromRgb(240, 222, 45));
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Bu_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //if (Bu.Toggled1 == true)
            //{
            //    Light.Fill = On;
            //}
            //else
            //{
            //    Light.Fill = Off;
            //}
        }

        private void openBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDlg = new Microsoft.Win32.OpenFileDialog();


            Nullable<bool> result = openFileDlg.ShowDialog();

            if (result == true)
            {
                using (StringReader reader = new StringReader(openFileDlg.FileName))
                {
                    patchLbl.Content = reader.ReadToEnd();
                    FileName = openFileDlg.FileName;
                    editorTxtb.Text = File.ReadAllText(patchLbl.Content.ToString());


                }
            }
        }

        private void cutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (editorTxtb.Text != null)
            {
                editorTxtb.Cut();
            }
        }

        private void copyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (editorTxtb.Text != null)
            {
                editorTxtb.Copy();
            }
        }

        private void pasteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (editorTxtb.Text != null)
            {
                editorTxtb.Paste();
            }
        }

        private void selectAllBtn_Click(object sender, RoutedEventArgs e)
        {
            if (editorTxtb.Text != null)
            {
                editorTxtb.SelectAll();
                editorTxtb.Focus();
            }
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();

            using (StreamWriter streamWriter = new StreamWriter(FileName))
            {
                streamWriter.Write(editorTxtb.Text);
            }
        }

        private void editorTxtb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Bu.Toggled1 == true)
            {
                SaveFileDialog save = new SaveFileDialog();

                using (StreamWriter streamWriter = new StreamWriter(FileName))
                {
                    streamWriter.Write(editorTxtb.Text);
                }
            }
        }

        
    }
}
