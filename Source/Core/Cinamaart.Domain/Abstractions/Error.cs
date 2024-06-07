﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    public sealed record Error(string Code , string? Description = null)
    {
        public static readonly Error None = new Error(string.Empty);

        public static implicit operator Result(Error error) => Result.Failure(error);
    }
}
