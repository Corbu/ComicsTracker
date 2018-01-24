using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdReprintToIssue
    {
        public int Id { get; set; }
        public int OriginId { get; set; }
        public int TargetIssueId { get; set; }
        public string Notes { get; set; }
        public byte Reserved { get; set; }

        public virtual GcdStory Origin { get; set; }
        public virtual GcdIssue TargetIssue { get; set; }
    }
}
