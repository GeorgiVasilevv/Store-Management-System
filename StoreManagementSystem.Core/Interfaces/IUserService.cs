﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManagementSystem.Core.Interfaces
{
    public interface IUserService
    {
        Task<bool> HasStoreWithIdAsync(string? userId, int storeId);
        Task<string> GetUserFullName(string email);
    }
}
