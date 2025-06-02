using aaaaaaa10_6.userControl;
using MaterialDesignThemes.Wpf;
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

namespace aaaaaaa10_6
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Dashboard());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void maximized(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                // إذا كانت مكبرة، قم بتصغيرها
                this.WindowState = WindowState.Normal;
                max_min.Kind = PackIconKind.WindowMaximize; // استخدم الأيقونة المناسبة للمصغر
            }
            else
            {
                // إذا لم تكن مكبرة، قم بتكبيرها
                this.WindowState = WindowState.Maximized;
                max_min.Kind = PackIconKind.WindowRestore; // استخدم الأيقونة المناسبة للتكبير
            }
        }


        private void Minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Home(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new home());
        }

        private void registration(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new registration());
        }

        private void interview(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new interview());
        }

        private void StudyMaterials(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new StudyMaterials());
        }

        private void AcademicStages(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new AcademicStages());
        }

        private void VacationsAndAbsences(object sender, RoutedEventArgs e)
        {

            RenderPages.Children.Clear();
            RenderPages.Children.Add(new VacationsAndAbsences());
        }

        private void Activities(object sender, RoutedEventArgs e)
        {

            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Activities());
        }

        private void homeliness(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new homeliness());
        }

        private void Research(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Research());
        }

        private void Practicality(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            RenderPages.Children.Add(new Practicality());
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
