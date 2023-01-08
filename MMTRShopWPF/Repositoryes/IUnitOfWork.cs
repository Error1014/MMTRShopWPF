﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTRShopWPF.Repositoryes
{
    internal interface IUnitOfWork:IDisposable
    {
        IProductRepository Products { get; }
        int Complete();
    }
}