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
    /// Логика взаимодействия для WindowStart.xaml
    /// </summary>
    public partial class WindowStart : Window
    {
        private MainWindow main3;
        public WindowStart(MainWindow main)
        {
            InitializeComponent();
            main3 = main;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var Regis = DATAframe.context.cRegister;
            var res = Regis.Where(i => i.LoginName == Login.Text && i.PasswordName == Password.Text).FirstOrDefault();


            if ((Login.Text.Length <= 0 || Password.Text.Length <= 0) || (Login.Text.Length <= 0 && Password.Text.Length <= 0))
            {
                MessageBox.Show("Введите логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (res == null)
                {
                    MessageBox.Show("Пользователь не авторизован", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    DATAframe.idClient = res.IDUser;
                    var Use = DATAframe.context.cUser.Where(i => i.IDUser == res.IDUser).FirstOrDefault();
                    var list = DATAframe.context.lList.Where(i => i.IDUser == res.IDUser).FirstOrDefault();
                    var lis = list;
                    MainWindow win = new MainWindow();
                   
                    if (list == null || res.IDUser != list.IDUser)
                    {
                        DATAframe.context.lList.Add(new lList
                        {
                            IDRegister = res.IDRegister,
                            IDUser = res.IDUser,
                            lName = Use.cName,
                            lNameS = Use.cNameS,
                            lLoginName = res.LoginName,
                            lImage = Use.cImage
                        });

                        DATAframe.context.SaveChanges();

                        MessageBox.Show("Пользователь найден", "Ура", MessageBoxButton.OK, MessageBoxImage.Information);
                        win.Show();
                        win.FRMain.Navigate(new Pages.PageLK(main3));

                        this.Close();
                    }
                    else 
                    {
                        MessageBox.Show("Пользователь уже авторизирован с этого компьютера!", "Сори", MessageBoxButton.OK, MessageBoxImage.Error);

                    }


                    win.FRMess.Navigate(new Pages.Page1(main3));
                }
            }


        }
    }
}
