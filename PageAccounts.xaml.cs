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
    /// Логика взаимодействия для PageAccounts.xaml
    /// </summary>
    public partial class PageAccounts : Page
    {
        private MainWindow main1;
        public PageAccounts(MainWindow main)
        {
            InitializeComponent();
            lvClient.ItemsSource = DATAframe.context.lList.ToList();
            main1 = main;

        }

        private void lvClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (lvClient.SelectedItem is lList list)
            {
               
                DATAframe.idClient = list.IDUser;
                main1.PageWin();
                
            }
            else
            {
                MessageBox.Show("Выбери шо нибудь пж", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            lvClient.ItemsSource = DATAframe.context.lList.ToList();
        }
    }
}
