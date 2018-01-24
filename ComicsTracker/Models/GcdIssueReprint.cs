using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdIssueReprint
    {
        public int Id { get; set; }
        public int OriginIssueId { get; set; }
        public int TargetIssueId { get; set; }
        public string Notes { get; set; }
        public byte Reserved { get; set; }

        public virtual GcdIssue OriginIssue { get; set; }
        public virtual GcdIssue TargetIssue { get; set; }
    }
}
