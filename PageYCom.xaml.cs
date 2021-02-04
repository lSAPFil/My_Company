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
    /// Логика взаимодействия для PageYCom.xaml
    /// </summary>
    public partial class PageYCom : Page
    {
        public PageYCom()
        {
            InitializeComponent();
            LVcom.ItemsSource = DATAframe.context.Comunity.ToList();
        }

        private void Enter_Click_1(object sender, RoutedEventArgs e)
        {
            if (LVcom.SelectedItem is Comunity com)
            {
                DATAframe.idCom = com.IDCom;
                var comm = DATAframe.context.Feed.Where(i => i.IDFeed == DATAframe.idCom).FirstOrDefault();
                DATAframe.context.Comunity.Remove(DATAframe.context.Comunity.Where(i => i.IDFeed == comm.IDFeed).FirstOrDefault());
                DATAframe.context.SaveChanges();
                MessageBox.Show("Группа удалена из ленты новостей", "Уведомление", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Выбери шо нибудь пж", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            LVcom.ItemsSource = DATAframe.context.Comunity.ToList();
        }
    }
}
