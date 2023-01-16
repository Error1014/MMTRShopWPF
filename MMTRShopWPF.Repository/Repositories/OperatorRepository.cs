﻿using MMTRShopWPF.Model.Models;
using MMTRShopWPF.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repository.Repositories
{
    public class OperatorRepository:Repository<Operator,Guid>, IOperatorRepository
    {
        public OperatorRepository(ShopContext context) : base(context)
        {
            
        }

        public Operator GetOperatorByUser(User user)
        {
            return ShopContext.Operator.FirstOrDefault(c => c.UserId == user.Id);
        }
    }
}
