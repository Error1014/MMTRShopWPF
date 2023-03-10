﻿using Shop.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Interface
{
    public interface IUserSessionSetter
    {
        void SetId(Guid id);
        void SetRole(string role);
    }
}