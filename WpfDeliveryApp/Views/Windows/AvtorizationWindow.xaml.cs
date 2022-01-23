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
using WpfDeliveryApp.Context;
using WpfDeliveryApp.Views.Windows.AdminWindows;
using WpfDeliveryApp.Views.Windows.ExecuterWindows;
using WpfDeliveryApp.Views.Windows.ManagerWindows;

namespace WpfDeliveryApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AvtorizationWindow : Window
    {
        public AvtorizationWindow()
        {
            InitializeComponent();
        }

        private void SeeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (VisiblePsw.Visibility == Visibility.Collapsed)
            {
                HiddenPsw.Visibility = Visibility.Collapsed;
                VisiblePsw.Visibility = Visibility.Visible;
            }
            else
            {
                HiddenPsw.Visibility = Visibility.Visible;
                VisiblePsw.Visibility = Visibility.Collapsed;
            }
        }

        private void psbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            txbPassword.Text = psbPassword.Password;
        }

        private void HideseeBtn_Click(object sender, RoutedEventArgs e)
        {

            if (HiddenPsw.Visibility == Visibility.Collapsed)
            {
                HiddenPsw.Visibility = Visibility.Visible;
                VisiblePsw.Visibility = Visibility.Collapsed;
            }
            else
            {
                HiddenPsw.Visibility = Visibility.Collapsed;
                VisiblePsw.Visibility = Visibility.Visible;
            }
        }

        private void psbPassword_PasswordChanged_1(object sender, RoutedEventArgs e)
        {

        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbPassword.Text == "" && txbLogin.Text == "")
                {
                    throw new Exception("Заполните все поля");
                }
                else
                {
                    // Запрос на авторизацию
                    var currentUser = Data.de.User.FirstOrDefault(item => item.Username == txbLogin.Text && item.Password == psbPassword.Password);
                    if (currentUser != null)
                    {
                        switch (currentUser.IDRole)
                        {
                            case "a":
                                AdminWindow adminWindow = new AdminWindow();
                                adminWindow.ShowDialog();
                                break;
                            case "m":
                                ManagerWindow managerWindow= new ManagerWindow();
                                managerWindow.ShowDialog();
                                break;
                            case "e":
                                ExecuterWindow executerWindow = new ExecuterWindow();
                                executerWindow.ShowDialog();
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Пользователь не найден!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверные данные", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    

    private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
