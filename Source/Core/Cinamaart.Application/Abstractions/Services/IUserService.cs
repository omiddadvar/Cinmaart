﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Abstractions.Services
{
    public interface IUserService
    {
        long? GetUserId();
        string? GetUserName();
    }
}
