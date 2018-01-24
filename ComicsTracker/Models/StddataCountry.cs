using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class StddataCountry
    {
        public StddataCountry()
        {
            GcdIndiciaPublisher = new HashSet<GcdIndiciaPublisher>();
            GcdPublisher = new HashSet<GcdPublisher>();
            GcdSeries = new HashSet<GcdSeries>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<GcdIndiciaPublisher> GcdIndiciaPublisher { get; set; }
        public virtual ICollection<GcdPublisher> GcdPublisher { get; set; }
        public virtual ICollection<GcdSeries> GcdSeries { get; set; }
    }
}
