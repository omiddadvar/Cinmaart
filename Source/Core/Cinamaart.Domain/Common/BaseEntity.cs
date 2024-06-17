using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cinamaart.Domain.Abstractions;

namespace Cinamaart.Domain.Common
{
    public class BaseEntity<TPrimaryKey> : IBaseEntity<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}
