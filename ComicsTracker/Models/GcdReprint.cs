using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdReprint
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int TargetId { get; set; }
        public string Notes { get; set; }
        public byte Reserved { get; set; }

        public virtual GcdStory Origin { get; set; }
        public virtual GcdStory Target { get; set; }
    }
}
