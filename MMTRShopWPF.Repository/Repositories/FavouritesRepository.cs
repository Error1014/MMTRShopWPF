﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMTRShopWPF.Repository.Repositories
{
    public class FavouritesRepository : Repository<Favourites>, IFavouritesRepository
    {
        public FavouritesRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public IEnumerable<Favourites> GetFavourites(Client client)
        {
            return ShopContext.Favourites.Where(k => k.ClientId == client.Id).ToList();
        }

        public Favourites GetFavourites(Client client, Product product)
        {
            return ShopContext.Favourites.Where(k => k.ClientId == client.Id && k.ProductId ==product.Id).FirstOrDefault();
        }
    }
}
