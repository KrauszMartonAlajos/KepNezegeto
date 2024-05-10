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

namespace KrauszMartonWPF_Projekt
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            kep1opcio.Visibility = Visibility.Visible;
            radioButton1.Checked += RadioButton_Checked;
            jobbra.Click += Button_Click;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            kep1opcio.Visibility = Visibility.Visible;
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //"kepek/kep2.jpg"
            kep1opcio.Source = new BitmapImage(new Uri("kepek/kep2.jpg", UriKind.RelativeOrAbsolute));

            MessageBox.Show("EHHE");
        }

    }
}
