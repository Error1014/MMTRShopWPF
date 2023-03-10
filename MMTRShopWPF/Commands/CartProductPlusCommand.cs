using MMTRShop.Model.Models;
using MMTRShop.Repository.Repositories;
using MMTRShop.Service.Services;
using MMTRShopWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Commands
{
    public class CartProductPlusCommand:BaseCommand<CartViewModel>
    {
        private CartService CartService = new CartService(new UnitOfWork(new ShopContext()));
        public CartProductPlusCommand(CartViewModel cartViewModel) : base(cartViewModel)
        {
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            Guid id = Guid.Parse(parameter.ToString());
            CartService.CartPlusOneProduct(id);
            viewModel.Cart = CartService.GetCart();
        }
    }
}
