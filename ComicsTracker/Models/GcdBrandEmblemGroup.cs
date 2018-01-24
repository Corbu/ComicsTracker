using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdBrandEmblemGroup
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int BrandgroupId { get; set; }

        public virtual GcdBrand Brand { get; set; }
        public virtual GcdBrandGroup Brandgroup { get; set; }
    }
}
