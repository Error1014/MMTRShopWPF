using Microsoft.EntityFrameworkCore;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShop.Repository.Repositories
{
    public class CartRepositiry : Repository<Cart, Guid>, ICartRepository
    {
        private readonly ShopContext _shopContext;
        public CartRepositiry(ShopContext context) : base(context)
        {
            _shopContext = context;
        }

        public async Task<Cart> GetCartByClient(Guid clientId)
        {
            return await _shopContext.Cart.Where(x => x.ClientId == clientId).FirstOrDefaultAsync();
        }
    }
}
