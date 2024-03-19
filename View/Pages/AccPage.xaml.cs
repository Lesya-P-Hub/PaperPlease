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
    /// Логика взаимодействия для AccPage.xaml
    /// </summary>
    public partial class AccPage : Page
    {
        public AccPage()
        {
            InitializeComponent();
            AccDg.ItemsSource = App.context.Acc.ToList();
            GroupCmb.SelectedValuePath = "Id";
            GroupCmb.DisplayMemberPath = "Name";
            GroupCmb.ItemsSource = App.context.Group.ToList();
            SpezCmb.SelectedValuePath = "Id";
            SpezCmb.DisplayMemberPath = "Name";
            SpezCmb.ItemsSource = App.context.Spez.ToList();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            string mes = "";
            if (string.IsNullOrEmpty(SpezCmb.Text))
            {
                mes += "Выберите параллель\n";
            }
            if (string.IsNullOrEmpty(GroupCmb.Text))
            {
                mes += "Выберите группу\n";
            }
            
            if(string.IsNullOrEmpty(CountTb.Text))
            {
                mes += "Введите бумагу (кг)\n";
            }
            if(string.IsNullOrEmpty(DateDp.Text))
            {
                mes += "Выберите дату\n";
            }
            if(mes != "")
            {
                MessageBox.Show(mes);
                mes = "";
                return;
            }

            Acc acc = new Acc()
            {
                Group = GroupCmb.SelectedItem as Group,
                Date = (DateTime)DateDp.SelectedDate,
                Kg = Convert.ToDecimal(CountTb.Text)
            };

            App.context.Acc.Add(acc);
            App.context.SaveChanges();
            MessageBox.Show("Отчёт обновлён");
            AccDg.ItemsSource = App.context.Acc.ToList();
            GroupCmb.Text = "";
            SpezCmb.Text = "";
            CountTb.Text = "";
            DateDp.Text = "";
        }

        private void SpezCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int SelectedType = Convert.ToInt32(SpezCmb.SelectedValue);
            GroupCmb.ItemsSource = App.context.Group.Where(x => x.SpezId == SelectedType).ToList();
        }
    }
}
