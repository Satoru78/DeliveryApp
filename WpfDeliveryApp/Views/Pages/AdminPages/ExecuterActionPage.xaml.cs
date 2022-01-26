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
using WpfDeliveryApp.Model;

namespace WpfDeliveryApp.Views.Pages.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для ExecuterActionPage.xaml
    /// </summary>
    public partial class ExecuterActionPage : Page
    {
        public Executer Executer { get; set; }
        public ExecuterActionPage(Executer executer)
        {
            InitializeComponent();
            Executer = executer;
            this.DataContext = this;
        }
        
        private void ExecuterAddbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(TextBoxFirstName.Text) && string.IsNullOrEmpty(TextBoxLastName.Text) &&
                    string.IsNullOrEmpty(TextBoxEmail.Text) && string.IsNullOrEmpty(TextBoxAddress.Text) &&
                    string.IsNullOrEmpty(TextBoxPhone.Text)) throw new Exception("Пожалуйста ,заполните все поля!");

                if (Executer.ID == 0)
                {
                    Data.de.Executer.Add(Executer);
                }
                Data.de.SaveChanges();
                MessageBox.Show("Данные успешно добавлены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
                GC.Collect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неизвестная Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TXB_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = "+1234567890".IndexOf(e.Text) < 0;
        }

    }
}

