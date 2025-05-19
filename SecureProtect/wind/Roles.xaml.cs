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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SecureProtect.wind
{
    /// <summary>
    /// Логика взаимодействия для Roles.xaml
    /// </summary>
    public partial class Roles : Window
    {
        public Roles()
        {
            InitializeComponent();
            Loaded += Window_Loaded;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            Storyboard titleAnimation = (Storyboard)FindResource("TitleAnimation");
            titleAnimation.Begin(titleText);
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void back(object sender, RoutedEventArgs e)
        {
            DashboardWindow m = new DashboardWindow();
            m.Show();
            this.Close();
        }
    }
}
