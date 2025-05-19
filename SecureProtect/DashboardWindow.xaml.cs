using SecureProtect.wind;
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

namespace SecureProtect
{
    /// <summary>
    /// Логика взаимодействия для DashboardWindow.xaml
    /// </summary>
    public partial class DashboardWindow : Window
    {
        public DashboardWindow()
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

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
           
            mainButtonsGrid.Visibility = Visibility.Visible;
            referencesGrid.Visibility = Visibility.Collapsed;
            btnHome.Visibility = Visibility.Collapsed;
            titleText.Text = "Добро пожаловать в SecureProtect!";
        }

        private void BtnReferences_Click(object sender, RoutedEventArgs e)
        {
  
            mainButtonsGrid.Visibility = Visibility.Collapsed;
            referencesGrid.Visibility = Visibility.Visible;
            btnHome.Visibility = Visibility.Visible;
            titleText.Text = "Справочники";
        }
        private void logout(object sender, RoutedEventArgs e)
        {
            MainWindow m = new MainWindow();
            m.Show();
            this.Close();
        }

        private void BtnDutySchedule_Click(object sender, RoutedEventArgs e)
        {
            Schedule s = new Schedule();
            s.Show();
            this.Close();
     
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        private void BtnFinancialReport_Click(object sender, RoutedEventArgs e)
        {
            Fin s = new Fin();
            s.Show();
            this.Close();

        }

        private void BtnContracts_Click(object sender, RoutedEventArgs e)
        {
            Dogovor s = new Dogovor();
            s.Show();
            this.Close();
        }

        private void BtnClients_Click(object sender, RoutedEventArgs e)
        {
            Clients s = new Clients();
            s.Show();
            this.Close();

        }

        private void BtnMakePayment_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Открыта форма внесения платежа", "Внести платеж", MessageBoxButton.OK, MessageBoxImage.Information);
            // Логика для внесения платежа
        }

        private void BtnEmployees_Click(object sender, RoutedEventArgs e)
        {
            Empl s = new Empl();
            s.Show();
            this.Close();
        }

        private void BtnPayments_Click(object sender, RoutedEventArgs e)
        {
            Plat s = new Plat();
            s.Show();
            this.Close();
        }

        // Функции справочников
        private void BtnPositions_Click(object sender, RoutedEventArgs e)
        {
            Positions s = new Positions();
            s.Show();
            this.Close();
        }

        private void BtnRoles_Click(object sender, RoutedEventArgs e)
        {
            Roles s = new Roles();
            s.Show();
            this.Close();
        }

        private void BtnEvents_Click(object sender, RoutedEventArgs e)
        {
            Events s = new Events();
            s.Show();
            this.Close();
        }

        private void BtnSpecialMeans_Click(object sender, RoutedEventArgs e)
        {
            SpecialMeans s = new SpecialMeans();
            s.Show();
            this.Close();
        }

        private void BtnObjects_Click(object sender, RoutedEventArgs e)
        {
            Objects s = new Objects();
            s.Show();
            this.Close();
        }

        private void BtnWeapons_Click(object sender, RoutedEventArgs e)
        {
            Weapons s = new Weapons();
            s.Show();
            this.Close();
        }
    
}
}
