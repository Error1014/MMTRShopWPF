﻿using MMTRShopWPF.Model;
using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MMTRShopWPF.Service.Services
{
    public class OrderService
    {
        UnitOfWork UnitOfWork { get; set; }
        public OrderService()
        {
            UnitOfWork = new UnitOfWork(new ShopContext());
        }
        public ObservableCollection<Order> GetOrders()
        {
            var orders = UnitOfWork.Orders.GetAll();
            return new ObservableCollection<Order>(orders);
        }
        public List<Order> GetOrderClient(Client client)
        {
            return UnitOfWork.Orders.GetOrdersByClientId(client.Id).ToList();
        }
        public Order GetOrder(Order order)
        {
            return UnitOfWork.Orders.Find(o=>o.Id==order.Id);
        }
        public void CreateOrder(Order order)
        {
            UnitOfWork.Orders.Add(order);
            SaveOrder();
        }
        public void SaveOrder()
        {
            UnitOfWork.Orders.Save();
        }

        
        
        #region Проверки введёных полей

        public bool CheckWrittenRequisitesBankCard(BankCard bankCard)
        {
            if (String.IsNullOrEmpty(bankCard.Number)
                || String.IsNullOrEmpty(bankCard.Name)
                || String.IsNullOrEmpty(bankCard.Code)
                || bankCard.Month == 0
                || bankCard.Year == 0) return false;
            else return true;
        }
        public bool CheckCorrectnessRequisitesBankCard(BankCard bankCard)
        {
            //В дальнейшем будет реализовано
            return true;
        }

        public bool CheckAddress(string address)
        {
            return !String.IsNullOrEmpty(address);
        }
        #endregion

        

    }
}
