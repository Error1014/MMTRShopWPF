﻿using MMTRShopWPF.Model;
using MMTRShopWPF.Service;
using System.Windows.Controls;

namespace MMTRShopWPF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
            NavigarionManager.MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel();
            DataContext = NavigationViewModel;

        }

        public MainPage(User user)
        {
            InitializeComponent();
            NavigarionManager.MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel(user);
            DataContext = NavigationViewModel;
        }

        public MainPage(Client client)
        {
            InitializeComponent();
            NavigarionManager.MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel(client);
            DataContext = NavigationViewModel;
        }

        public MainPage(Admin admin)
        {
            InitializeComponent();
            NavigarionManager.MainFrame = MyFrame;
            NavigationViewModel NavigationViewModel = new NavigationViewModel(admin);
            DataContext = NavigationViewModel;
        }
    }
}
