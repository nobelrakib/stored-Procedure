﻿using System;
using System.Collections.Generic;
using System.Text;
using Ecommerce.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Core.Entities
{
    public class ProductImage
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string AlternativeText { get; set; }
        public Product Product { get; set; }
    }
}
