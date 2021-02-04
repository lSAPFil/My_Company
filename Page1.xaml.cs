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

namespace MyProject.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        MainWindow main1;
        public Page1(MainWindow main)
        {
            InitializeComponent();
            main1 = main;
        }

        private void btnFeed_Click(object sender, RoutedEventArgs e)
        {
            main1.PageWin3();
        }

        private void btnMess_Click(object sender, RoutedEventArgs e)
        {
            main1.PageWin4();
        }

        private void btnLK_Click(object sender, RoutedEventArgs e)
        {
            main1.PageWin();
        }

        private void btnCom_Click(object sender, RoutedEventArgs e)
        {
            main1.PageWin6();
        }

        private void btnYCom_Click(object sender, RoutedEventArgs e)
        {
            main1.PageWin7();
        }
    }
}
