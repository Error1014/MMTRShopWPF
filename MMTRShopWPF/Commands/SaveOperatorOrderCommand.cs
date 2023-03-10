using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.View.Pages;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class SaveOperatorOrderCommand : BaseCommand<InfoOperatorOrderViewModel>
    {
        private OrderService OrderService = new OrderService(new UnitOfWork(new ShopContext()));
        public SaveOperatorOrderCommand(InfoOperatorOrderViewModel vm) : base(vm)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            Order order = OrderService.GetOrder(viewModel.Order);
            order.StatusId = viewModel.Order.StatusId;
            order.DateDelivery = viewModel.Order.DateDelivery;
            OrderService.SaveOrder();
            NavigarionManager.MainFrame.Content = new OrdersPage();

        }
    }
}
