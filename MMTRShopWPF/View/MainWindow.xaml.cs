﻿using MMTRShopWPF.Service;
using MMTRShopWPF.View.Pages;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MMTRShopWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Frame MainWindowFrame;
        public MainWindow()
        {
            InitializeComponent();
            MainWindowFrame = MainFrame;
            MainWindowFrame.Content = new MainPage();
            //using (var db = new ShopContext())
            //{
            //    var user = new User("1", "2", "3", "4", "5");
            //    db.User.Add(user);
            //    db.SaveChanges();
            //}
        }
    }
}
