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
using PaperPlease.Model;

namespace PaperPlease.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PapperPage.xaml
    /// </summary>
    public partial class PapperPage : Page
    {
        public PapperPage()
        {
            InitializeComponent();
        }

        private void SearchTb_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if(string.IsNullOrEmpty(StartDp.Text))
            {
                mes += "Введите начало периода\n";
            }
            if(string.IsNullOrEmpty(FinishDp.Text))
            {
                mes += "Введите конец периода\n";
            }

            if(mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            var a = (DateTime)StartDp.SelectedDate;
            var b = (DateTime)FinishDp.SelectedDate;
            var qwery = App.context.View_1
                .Where(x => x.Date >= a && x.Date <= b)
                .GroupBy(c => c.Name)
                .Select(g => new { Группа = g.Key, Бумага = g.Sum(s => s.Kg) })
                .OrderByDescending(y => y.Бумага);

            AccDg.ItemsSource = qwery.ToList();
        }
    }
}
