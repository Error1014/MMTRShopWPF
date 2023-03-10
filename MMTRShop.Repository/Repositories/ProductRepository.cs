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
    public class ProductRepository : Repository<Product,Guid>, IProductRepository
    {
        public ProductRepository(ShopContext context) : base(context)
        {

        }
        public async Task<IEnumerable<Product>> GetProductsPage(ProductPageFilter filter)
        {
            var query = Set;
            if (filter.CategoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == filter.CategoryId);
            }
            if (filter.BrandId.HasValue)
            {
                query = query.Where(x => x.BrandId == filter.BrandId);
            }
            query = query
                .OrderBy(x => x.Id)
                .Skip((filter.NumPage - 1) * filter.SizePage)
                .Take(filter.SizePage);
            return await query.ToListAsync();
        }
    }
}
