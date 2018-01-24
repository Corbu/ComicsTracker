using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdIndiciaPublisher
    {
        public GcdIndiciaPublisher()
        {
            GcdIssue = new HashSet<GcdIssue>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int CountryId { get; set; }
        public int? YearBegan { get; set; }
        public int? YearEnded { get; set; }
        public byte IsSurrogate { get; set; }
        public string Notes { get; set; }
        public string Url { get; set; }
        public int IssueCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public byte Reserved { get; set; }
        public byte Deleted { get; set; }
        public byte YearBeganUncertain { get; set; }
        public byte YearEndedUncertain { get; set; }

        public virtual ICollection<GcdIssue> GcdIssue { get; set; }
        public virtual StddataCountry Country { get; set; }
        public virtual GcdPublisher Parent { get; set; }
    }
}
