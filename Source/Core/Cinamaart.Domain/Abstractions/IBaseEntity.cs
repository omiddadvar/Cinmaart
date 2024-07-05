﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Abstractions
{
    public interface IBaseEntity<TPrimaryKey> : IEntity
    {
        [NotMapped]
        public TPrimaryKey Id { get; set; }
    }
}
