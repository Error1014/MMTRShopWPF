﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Commands
{
    public class MyOrderViewModel:BaseViewModel
    {
        private OrderService OrderService = new OrderService();
        private OrderContentService OrderContentService = new OrderContentService();
        public MyOrderViewModel()
        {
            Orders = OrderService.GetOrderClient(AccountManager.Client);
            OrderContents = OrderContentService.GetOrderContentNoСompleted(Orders);

        }
        private List<Order> orders;
        public List<Order> Orders
        {
            get { return orders; }
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Order));
            }
        }

        private List<OrderContent> orderContents;
        public List<OrderContent> OrderContents
        {
            get { return orderContents; }
            set
            {
                orderContents = value;
                OnPropertyChanged(nameof(OrderContents));
            }
        }


    }

    
}
