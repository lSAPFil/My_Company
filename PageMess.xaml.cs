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
    /// Логика взаимодействия для PageMess.xaml
    /// </summary>
    public partial class PageMess : Page
    {
        public MainWindow main1;
        public PageMess(MainWindow main)
        {
            InitializeComponent();
            LVMess.ItemsSource = DATAframe.context.Mess.ToList();
            main1 = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (LVMess.SelectedItem is Mess list)
            {
                DATAframe.idMess = list.IDMess;
                main1.PageWin5();
            }
            else
            {
                MessageBox.Show("Выбери шо нибудь пж", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            LVMess.ItemsSource = DATAframe.context.Mess.ToList();
        }
    }
}
