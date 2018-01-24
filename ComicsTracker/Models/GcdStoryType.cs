using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdStoryType
    {
        public GcdStoryType()
        {
            GcdStory = new HashSet<GcdStory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SortCode { get; set; }

        public virtual ICollection<GcdStory> GcdStory { get; set; }
    }
}
