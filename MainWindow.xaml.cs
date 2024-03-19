using PaperPlease.AppData;
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

namespace PaperPlease
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            FrameClass.BodyFrame = BodyFrm;
            BodyFrm.Navigate(new View.Pages.AccPage());
             
        }

        private void AccAddBtn_Click(object sender, RoutedEventArgs e)
        {
            BodyFrm.Navigate(new View.Pages.AccPage());
        }

        private void AccPaperBtn_Click(object sender, RoutedEventArgs e)
        {
            BodyFrm.Navigate(new View.Pages.PapperPage());
        }

        private void Acc2Btn_Click(object sender, RoutedEventArgs e)
        {
            BodyFrm.Navigate(new View.Pages.FinalPage());
        }
    }
}
