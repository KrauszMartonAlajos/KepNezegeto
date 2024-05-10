using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace _2024_02_24_Kepnezegeto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Photos photos;
        string path = "h:/KrauszMartonWPF_Projekt/2024_04_24_Kepnezegeto/images";
        ICollectionView myView;
        int mode = 1;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded; //this.Loaded += TAB TAB
        }

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var files = new DirectoryInfo(path).GetFiles().ToList();
            photos = new Photos(files);
            this.DataContext = photos;  // Az ablakohoz hozzáadom az összes képet használatra.

            myView = CollectionViewSource.GetDefaultView(photos);
            this.DataContext = myView;

            //Nézi a mappa tartalmát, hogy kerül-e bele új kép.
            FileSystemWatcher fsw = new FileSystemWatcher(path);
            fsw.Created += FswCreated;
            fsw.EnableRaisingEvents = true;
        
        }

        private void FswCreated(object sender, FileSystemEventArgs e)
        {
            //Ha új képet töltünk be
            if (e.ChangeType == WatcherChangeTypes.Created)
            {
                //Diszépcserrel ellenőrzött módon tud a két szál között kommunikálni.
                Dispatcher.Invoke(new ThreadStart(() =>
                {
                    FileInfo fs = new FileInfo(e.FullPath);
                    // Ez külön szálon fut.Ezért ezt nem támogatja. Dispécsert kell használni a két szál között.
                    photos.Insert(0, fs);
                }));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myView.SortDescriptions.Add(
                new SortDescription("Name", ListSortDirection.Descending));
            //myView.SortDescriptions.Add(
            //    new SortDescription("LastAccessTime", ListSortDirection.Descending));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            myView.GroupDescriptions.Clear();
            myView.GroupDescriptions.Add(
                new PropertyGroupDescription("LastWriteTime", new MonthConverter()));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("1.mód");
            mode = 1;
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("2.mód");
            mode = 2;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("3.mód");
            mode = 3;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("balra");
        }
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("jobbra");
        }
    }
}
