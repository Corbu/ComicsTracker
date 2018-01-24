using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdBrandUse
    {
        public int Id { get; set; }
        public int PublisherId { get; set; }
        public int EmblemId { get; set; }
        public int? YearBegan { get; set; }
        public int? YearEnded { get; set; }
        public byte YearBeganUncertain { get; set; }
        public byte YearEndedUncertain { get; set; }
        public string Notes { get; set; }
        public byte Reserved { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        public virtual GcdBrand Emblem { get; set; }
        public virtual GcdPublisher Publisher { get; set; }
    }
}
