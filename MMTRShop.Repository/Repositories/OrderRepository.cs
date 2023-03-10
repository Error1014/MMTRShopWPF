using Microsoft.EntityFrameworkCore;
using Shop.Infrastructure.HelperModels;
using MMTRShop.Repository.Entities;
using MMTRShop.Repository.Contexts;
using MMTRShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShop.Repository.Repositories
{
    public class OrderRepository:Repository<Order,Guid>,IOrderRepository
    {
        public OrderRepository(ShopContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Order>> GetOrders(OrderFilter filter)
        {
            var query = ShopContext.Order.AsQueryable();
            if (filter.ClientId.HasValue)
            {
                query = query.Where(x => x.ClientId == filter.ClientId);
            }
            if (filter.StatusId.HasValue)
            {
                query = query.Where(x => x.StatusId == filter.StatusId);
            }
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
