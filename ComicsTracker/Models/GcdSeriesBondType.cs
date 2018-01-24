using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdSeriesBondType
    {
        public GcdSeriesBondType()
        {
            GcdSeriesBond = new HashSet<GcdSeriesBond>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<GcdSeriesBond> GcdSeriesBond { get; set; }
    }
}
