using PaperPlease.AppData;
using PaperPlease.Model;
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

namespace PaperPlease.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для FinalPage.xaml
    /// </summary>
    public partial class FinalPage : Page
    {
        public FinalPage()
        {
            InitializeComponent();
            SpezCmb.SelectedValuePath = "Id";
            SpezCmb.DisplayMemberPath = "Name";
            SpezCmb.ItemsSource = App.context.Spez.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new View.Pages.Final2Page((sender as Button).DataContext as Group));

        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            int SelectedS = Convert.ToInt32(SpezCmb.SelectedValue);
            InfoDg.ItemsSource = App.context.Group.Where(x => x.SpezId == SelectedS).ToList();
            
        }
    }
}
