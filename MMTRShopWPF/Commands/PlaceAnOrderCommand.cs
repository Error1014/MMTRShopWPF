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
    public class PlaceAnOrderCommand:BaseCommand<OrderViewModel>
    {
        private OrderService OrderService = new OrderService(new UnitOfWork(new ShopContext()));
        private OrderContentService OrderContentService = new OrderContentService(new UnitOfWork(new ShopContext()));
        private CartService CartService = new CartService(new UnitOfWork(new ShopContext()));
        private ProductService ProductService = new ProductService(new UnitOfWork(new ShopContext()));
        public PlaceAnOrderCommand(OrderViewModel orderViewModel) : base(orderViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            if (CheckAll())
            {
                viewModel.Order.DateOrder = DateTime.Now;
                viewModel.Order.DateDelivery = viewModel.Order.DateOrder;
                viewModel.Order.StatusId = viewModel.Status.Id;
                viewModel.Order.ClientId = AccountManager.Client.Id;

                OrderService.CreateOrder(viewModel.Order);
                OrderContentService.CreateOrderContent(viewModel.Order);
                ProductService.RemoveProductsInStorage(viewModel.Carts);
                CartService.ClearCart();
                NavigarionManager.MainFrame.Content = new MyOrderPage();
            }
        }

        #region Проверки введёных полей

        private bool CheckAll()
        {

            if (viewModel.IsPayNow)
            {
                viewModel.Message = OrderService.CheckWrittenRequisitesBankCard(viewModel.BankCardVM.BankCard);
                if (viewModel.Message.IsError()) return false;
                viewModel.Message = OrderService.CheckCorrectnessRequisitesBankCard(viewModel.BankCardVM.BankCard);
                if (viewModel.Message.IsError()) return false;
            }
            viewModel.Message = OrderService.CheckAddress(viewModel.Order.Address);
            if (viewModel.Message.IsError()) return false;
            return true;
        }
        #endregion
    }
}
