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
    /// Логика взаимодействия для PageCom.xaml
    /// </summary>
    public partial class PageCom : Page
    {
        private MainWindow main1;
        public PageCom(MainWindow main)
        {
            InitializeComponent();
            LVcom.ItemsSource = DATAframe.context.Feed.ToList();
            main1 = main;
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            

            
        }

        private void Enter_Click_1(object sender, RoutedEventArgs e)
        {
            if (LVcom.SelectedItem is Feed feed)
            {
                DATAframe.idCom = feed.IDFeed;
                var com = DATAframe.context.Feed.Where(i => i.IDFeed == DATAframe.idCom).FirstOrDefault();

                DATAframe.context.Comunity.Add(new Comunity
                {
                    IDFeed = com.IDFeed,
                    Group = com.Goup,
                    Post = com.Post,
                    Fimage = com.Fimage

                });
                DATAframe.context.SaveChanges();
                MessageBox.Show("Группа добавлена в ленту новостей", "Уведомление", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Выбери шо нибудь пж", "Notification", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

           LVcom.ItemsSource = DATAframe.context.Feed.ToList();
        }
    }
}
