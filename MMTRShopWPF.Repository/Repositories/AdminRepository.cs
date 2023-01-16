﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repository.Repositories
{
    public class AdminRepository:Repository<Admin>,IAdminRepository
    {
        public AdminRepository(ShopContext context) : base(context)
        {

        }

        public ShopContext ShopContext
        {
            get { return Context as ShopContext; }
        }

        public Admin GetAdminByUserId(Guid id)
        {
            return ShopContext.Admin.Where(c => c.UserId == id).FirstOrDefault();
        }
    }
}