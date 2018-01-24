using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdSeriesPublicationType
    {
        public GcdSeriesPublicationType()
        {
            GcdSeries = new HashSet<GcdSeries>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<GcdSeries> GcdSeries { get; set; }
    }
}
