using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdPublisher
    {
        public GcdPublisher()
        {
            GcdBrand = new HashSet<GcdBrand>();
            GcdBrandGroup = new HashSet<GcdBrandGroup>();
            GcdBrandUse = new HashSet<GcdBrandUse>();
            GcdIndiciaPublisher = new HashSet<GcdIndiciaPublisher>();
            GcdSeries = new HashSet<GcdSeries>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int? YearBegan { get; set; }
        public int? YearEnded { get; set; }
        public string Notes { get; set; }
        public string Url { get; set; }
        public byte IsMaster { get; set; }
        public int? ParentId { get; set; }
        public int ImprintCount { get; set; }
        public int BrandCount { get; set; }
        public int IndiciaPublisherCount { get; set; }
        public int SeriesCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public int IssueCount { get; set; }
        public byte Reserved { get; set; }
        public byte Deleted { get; set; }
        public byte YearBeganUncertain { get; set; }
        public byte YearEndedUncertain { get; set; }

        public virtual ICollection<GcdBrand> GcdBrand { get; set; }
        public virtual ICollection<GcdBrandGroup> GcdBrandGroup { get; set; }
        public virtual ICollection<GcdBrandUse> GcdBrandUse { get; set; }
        public virtual ICollection<GcdIndiciaPublisher> GcdIndiciaPublisher { get; set; }
        public virtual ICollection<GcdSeries> GcdSeries { get; set; }
        public virtual StddataCountry Country { get; set; }
        public virtual GcdPublisher Parent { get; set; }
        public virtual ICollection<GcdPublisher> InverseParent { get; set; }
    }
}
