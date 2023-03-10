using MMTRShop.Model;
using MMTRShop.Model.Models;
using MMTRShop.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для EditInfoProductPage.xaml
    /// </summary>
    public partial class EditInfoProductPage : Page
    {
        public EditInfoProductPage()
        {
            InitializeComponent();
        }
        public EditInfoProductPage(Product product)
        {
            InitializeComponent();
            EditProductViewModel editProductViewModel = new EditProductViewModel(product);
            DataContext = editProductViewModel;
        }

        private void ItputNumber(object sender, TextCompositionEventArgs e)
        {
            Regex reg = new Regex("[^0-9]");
            e.Handled = reg.IsMatch(e.Text);
        }
    }
}
