using Microsoft.Win32;
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
using System.Windows.Shapes;
using static MyProject.DATAframe;

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для WindowRegis.xaml
    /// </summary>
    public partial class WindowRegis : Window
    {
        private string PhotoImage;
        private MainWindow main1;
        public WindowRegis(MainWindow main)
        {
            InitializeComponent();
            main1 = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAddNew(object sender, RoutedEventArgs e)
        {

            if (string.IsNullOrWhiteSpace(FNAME.Text) ||
                string.IsNullOrWhiteSpace(MNAME.Text) ||
                string.IsNullOrWhiteSpace(LOGIN.Text) ||
                string.IsNullOrWhiteSpace(PASSWORD.Text)||
                string.IsNullOrWhiteSpace(RPASSWORD.Text))
            {
                MessageBox.Show("Заполните обязательные поля для ввода!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                if(RPASSWORD.Text!=PASSWORD.Text)
                {
                    MessageBox.Show("Пароли должны совпадать!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                if (PASSWORD.Text.Length < 6)
                {
                    MessageBox.Show("Размер пароля должен быть не менее 6 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }

            
            context.cUser.Add(new cUser
            {
                cName = FNAME.Text,
                cNameS = MNAME.Text,
                cDate = Date.DisplayDate,
                cImage = File.ReadAllBytes(PhotoImage)
            });
            context.SaveChanges();

            var Use = DATAframe.context.cUser;
            var ues = Use.Where(i => i.cName == FNAME.Text && i.cNameS == MNAME.Text).FirstOrDefault();
            
            context.cRegister.Add(new cRegister
            {
                IDUser = ues.IDUser,
                LoginName = LOGIN.Text,
                PasswordName = PASSWORD.Text
            });

            context.SaveChanges();

            DATAframe.idClient = ues.IDUser;

            var Use1 = DATAframe.context.cUser.Where(i => i.IDUser == ues.IDUser).FirstOrDefault();
            var v = DATAframe.context.cRegister.Where(i => i.IDUser == ues.IDUser).FirstOrDefault();
            var list = DATAframe.context.lList.Where(i => i.IDUser == ues.IDUser).FirstOrDefault();
            var lis = list;
            if (list == null || ues.IDUser != list.IDUser)
            {
                DATAframe.context.lList.Add(new lList
                {
                    IDRegister = v.IDRegister,
                    IDUser = ues.IDUser,
                    lName = Use1.cName,
                    lNameS = Use1.cNameS,
                    lLoginName = v.LoginName,
                    lImage = Use1.cImage
                });

                DATAframe.context.SaveChanges();

                MessageBox.Show($"Аккаунт {FNAME.Text} {MNAME.Text} успешно добавлен", "Сообщение");
                main1.PageWin();
            }

            main1.FRMess.Navigate(new Pages.Page1(main1));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog OPD = new OpenFileDialog();
            if (OPD.ShowDialog() == true)
            {
                photoUser.Source = new BitmapImage(new Uri(OPD.FileName));
                PhotoImage = OPD.FileName;
            }
        }
    }
}
