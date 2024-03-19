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
    /// Логика взаимодействия для Final2Page.xaml
    /// </summary>
    public partial class Final2Page : Page
    {
        public Final2Page(Group group)
        {
            InitializeComponent();
            JournalDg.ItemsSource = App.context.Acc.Where(x => x.GroupId == group.Id).ToList();
        }

        private void PrintBtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintVisual(JournalDg, "Бумага (кг)");
        }
    }
}
