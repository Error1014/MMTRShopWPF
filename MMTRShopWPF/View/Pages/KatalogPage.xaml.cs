using MMTRShop.Model;
using MMTRShop.Service.Services;
using MMTRShopWPF.ViewModels;
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

namespace MMTRShopWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для KatalogPage.xaml
    /// </summary>
    public partial class KatalogPage : Page
    {
        KatalogViewModel katalogViewModel = new KatalogViewModel();
        public KatalogPage()
        {
            InitializeComponent();
        }

        private void SelectProduct(object sender, SelectionChangedEventArgs e)
        {
            katalogViewModel.SelectProduct(sender);
        }
    }
}
