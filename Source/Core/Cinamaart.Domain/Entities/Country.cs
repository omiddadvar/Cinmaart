﻿using Cinamaart.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Entities
{
    [Table("Countries")]
    public class Country : BaseEntity<int>
    {
        [StringLength(100) , DataType("VARCHAR")]
        public string Name {  get; set; }
    }
}
