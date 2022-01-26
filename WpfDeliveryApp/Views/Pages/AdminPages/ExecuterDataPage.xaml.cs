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
    /// Логика взаимодействия для ExecuterDataPage.xaml
    /// </summary>
    public partial class ExecuterDataPage : Page
    {
        public ExecuterDataPage()
        {
            InitializeComponent();
        }

        private void Searchtxb_TextChanged(object sender, TextChangedEventArgs e)
        {
            var list = Data.de.Executer.Where(item => item.FirstName.Contains(Searchtxb.Text) ||
            item.LastName.Contains(Searchtxb.Text) || item.Phone.Contains(Searchtxb.Text) || item.Email.Contains(Searchtxb.Text)).ToList();

            if (list.Any())
            {
                GridExecuter.Visibility = Visibility.Visible;
                GridNonResult.Visibility = Visibility.Collapsed;
                ExecuterView.ItemsSource = list;
            }
            else
            {
                GridExecuter.Visibility = Visibility.Collapsed;
                GridNonResult.Visibility = Visibility.Visible;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ExecuterView.ItemsSource = Data.de.Executer.ToList();
        }

        private void AddViewBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ExecuterActionPage(new Executer()));
        }

        private void EditViewBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItemExecuter = ExecuterView.SelectedItem as Executer;
                if (selectedItemExecuter != null)
                    NavigationService.Navigate(new ExecuterActionPage(selectedItemExecuter));
                else
                    throw new Exception("Пожалуйста, выберите объект из списка!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedItemExecuter = ExecuterView.SelectedItem as Executer;
                if (selectedItemExecuter != null)
                {
                    if (MessageBox.Show("Вы дествительно хотите удалить данные?", "Данные будут удалены навсегда!", MessageBoxButton.OKCancel, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    {
                        Data.de.Executer.Remove(selectedItemExecuter);
                        Data.de.SaveChanges();
                        MessageBox.Show("Данные успешно удалены", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        Page_Loaded(null, null);
                    }

                }
                else
                    throw new Exception("Пожалуйста, выберите объект из списка!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

   
    }
}
