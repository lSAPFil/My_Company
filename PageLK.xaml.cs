using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PageLK.xaml
    /// </summary>
    public partial class PageLK : Page
    {
        private MainWindow main1;
        public PageLK(MainWindow main)
        {
            
            InitializeComponent();
            var user = DATAframe.context.cUser.Where(i => i.IDUser == DATAframe.idClient).FirstOrDefault();
            var reg = DATAframe.context.cRegister.Where(i => i.IDUser == DATAframe.idClient).FirstOrDefault();
            NamePA.Text = user.cName;
            LNamePA.Text = user.cNameS;
            NikPA.Text = reg.LoginName;
            DatePA.Text = user.cDate.ToString();

            main1 = main;

            if (user.cImage != null)
            {
                Binding cmi = new Binding("cImage")
                {
                    Source = user
                };
                photoUser.SetBinding(Image.SourceProperty, cmi);
            }
            
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var Use = DATAframe.context.cUser.Where(i => i.IDUser == DATAframe.idClient).FirstOrDefault();

            DATAframe.context.lList.Remove(DATAframe.context.lList.Where(i => i.IDUser == Use.IDUser).FirstOrDefault());
            DATAframe.context.SaveChanges();

            MainWindow w = new MainWindow();

            main1.PageWin2();
            main1.FRMess.Content = null;

            //Выход из аккаунта сопровождается отсутсвием на странице ЛК иконки с ссылкой пользователя
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            WindowEdit edit = new WindowEdit(main1);
            edit.Show();
        }
    }
}
