﻿using MMTRShopWPF.Model;
using MMTRShopWPF.Service.Services;
using System.Windows.Controls;

namespace MMTRShopWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для KorzinaPage.xaml
    /// </summary>
    public partial class KorzinaPage : Page
    {
        public static CartViewModel korzinaViewModel;
        public KorzinaPage()
        {
            InitializeComponent();
            UpdateDataContext();
        }

        public void UpdateDataContext()
        {
            korzinaViewModel = new CartViewModel(this);
            DataContext = korzinaViewModel;
        }
    }
}
