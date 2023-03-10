using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MMTRShopWPF.Commands
{
    public class CartProductMinusCommand:BaseCommand<CartViewModel>
    {
        private CartService CartService = new CartService(new UnitOfWork(new ShopContext()));
        public CartProductMinusCommand(CartViewModel cartViewModel) : base(cartViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            Guid id = Guid.Parse(parameter.ToString());
            CartService.CartMinusOneProduct(id);
            viewModel.Cart = CartService.GetCart();
        }
    }
}

