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

namespace MyProject
{
    /// <summary>
    /// Логика взаимодействия для WindowEdit.xaml
    /// </summary>
    public partial class WindowEdit : Window
    {
        public MainWindow main1;
        private string PhotoImage;
        public WindowEdit(MainWindow main)
        {
            InitializeComponent();
            var reg = DATAframe.context.cRegister.Where(i => i.IDUser == DATAframe.idClient).FirstOrDefault();
            var user = DATAframe.context.cUser.Where(i => i.IDUser == DATAframe.idClient).FirstOrDefault();

            main1 = main;

            FNAME.Text = user.cName;
            MNAME.Text = user.cNameS;
            LOGIN.Text = reg.LoginName;
            PASSWORD.Text = reg.PasswordName;
            RPASSWORD.Text = reg.PasswordName;

            if (user.cImage != null)
            {
                Binding cmi = new Binding("cImage")
                {
                    Source = user
                };
                photoUser.SetBinding(Image.SourceProperty, cmi);
            }
        }

        private void BtnAddNew(object sender, RoutedEventArgs e)
        {



            if (RPASSWORD.Text != PASSWORD.Text)
            {
                MessageBox.Show("Пароли должны совпадать!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (PASSWORD.Text.Length < 6)
            {
                MessageBox.Show("Размер пароля должен быть не менее 6 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (RPASSWORD.Text != PASSWORD.Text)
            {
                MessageBox.Show("Пароли должны совпадать!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if (PASSWORD.Text.Length < 6)
            {
                MessageBox.Show("Размер пароля должен быть не менее 6 символов!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            cUser user = DATAframe.context.cUser.Add(new cUser
                {
                    cName = FNAME.Text,
                    cNameS = MNAME.Text,
                    cDate = Date.DisplayDate,
                    cImage = File.ReadAllBytes(PhotoImage),
                    cNik = LOGIN.Text
                });
                DATAframe.context.SaveChanges();

                var Use = DATAframe.context.cUser;
                var ues = Use.Where(i => i.cName == FNAME.Text && i.cNameS == MNAME.Text).FirstOrDefault();

            cRegister reg = DATAframe.context.cRegister.Add(new cRegister
                {
                    IDUser = ues.IDUser,
                    LoginName = LOGIN.Text,
                    PasswordName = PASSWORD.Text
                });

                DATAframe.context.SaveChanges();
            DATAframe.idClient = ues.IDUser;
            

            var Use1 = DATAframe.context.cUser.Where(i => i.IDUser == ues.IDUser).FirstOrDefault();
            var v = DATAframe.context.cRegister.Where(i => i.IDUser == ues.IDUser).FirstOrDefault();
            var list = DATAframe.context.lList.Where(i => i.IDUser == ues.IDUser).FirstOrDefault();
            var lis = list;
                lList lister = DATAframe.context.lList.Add(new lList
                {
                    IDRegister = v.IDRegister,
                    IDUser = ues.IDUser,
                    lName = Use1.cName,
                    lNameS = Use1.cNameS,
                    lLoginName = v.LoginName,
                    lImage = Use1.cImage
                });

            DATAframe.context.SaveChanges();

            MessageBox.Show($"Аккаунт {FNAME.Text} {MNAME.Text} успешно редактирован", "Сообщение");
            this.Close();
            main1.PageWin();

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
