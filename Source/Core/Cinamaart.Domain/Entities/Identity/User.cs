﻿using Cinamaart.Domain.Common.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities.Identity
{
    public class User : IdentityUser<long>, IEntity<long>
    {

    }
}
