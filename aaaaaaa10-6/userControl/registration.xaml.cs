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

namespace aaaaaaa10_6.userControl
{
    /// <summary>
    /// Interaction logic for registration.xaml
    /// </summary>
    public partial class registration : UserControl
    {
        public registration()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            GridRegisteration.Children.Clear();
            
        }
    }
}
