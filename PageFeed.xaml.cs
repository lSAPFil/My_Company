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
using static MyProject.DATAframe;

namespace MyProject.Pages
{

    /// <summary>
    /// Логика взаимодействия для PageFeed.xaml
    /// </summary>
    public partial class PageFeed : Page
    {
        public PageFeed()
        {

            InitializeComponent();
            LVFeed.ItemsSource = DATAframe.context.Comunity.ToList();
            
        }
    }
}
