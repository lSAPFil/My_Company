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
    /// Логика взаимодействия для PageDialog.xaml
    /// </summary>
    public partial class PageDialog : Page
    {
        public PageDialog()
        {
            InitializeComponent();

            LVSMS.ItemsSource = DATAframe.context.SMS.Where(i => i.IDMess == DATAframe.idMess).ToList();

            var us = DATAframe.context.Mess.Where(i => i.IDMess == DATAframe.idMess).FirstOrDefault();

            tbUserMessName.Text = us.UserMess;
            if(us.Mimage!=null)
            {
                Binding cmi = new Binding("Mimage")
                {
                    Source = us
                };
                ImageI.SetBinding(Image.SourceProperty, cmi);
            }
            


        }
    }
}


