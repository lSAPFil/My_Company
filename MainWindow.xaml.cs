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

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void PageWin5()
        {
            FRMain.Navigate(new Pages.PageDialog());
        }  
        public void PageWin6()
        {
            FRMain.Navigate(new Pages.PageCom(this));
        }
        public void PageWin7()
        {
            FRMain.Navigate(new Pages.PageYCom());
        }
        public void PageWin3()
        {
            FRMain.Navigate(new Pages.PageFeed());
        }
        public void PageWin()
        {
            FRMain.Navigate(new Pages.PageLK(this));
            FRMess.Navigate(new Pages.Page1(this));
        }
        public void PageWin4()
        {
            FRMain.Navigate(new Pages.PageMess(this));
        }
        public void PageWin2()
        {
            FRMain.Navigate(new Pages.PageAccounts(this));
        }
        public MainWindow()
        {
            InitializeComponent();

           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WindowStart start = new WindowStart(this);
            this.Close();
            start.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowRegis reg = new WindowRegis(this);
            reg.Show();

        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            FRMain.Navigate(new Pages.PageAccounts(this));

        }
    }

       
}
