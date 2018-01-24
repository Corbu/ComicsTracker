using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class StddataLanguage
    {
        public StddataLanguage()
        {
            GcdSeries = new HashSet<GcdSeries>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string NativeName { get; set; }

        public virtual ICollection<GcdSeries> GcdSeries { get; set; }
    }
}
