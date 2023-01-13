﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;

namespace MMTRShopWPF.Repository.Repository
{
    public class UserRepository:Repository<User>,IUserRepository
    {
        public UserRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }
    }
}