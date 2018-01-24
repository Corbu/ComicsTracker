using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdIssue
    {
        public GcdIssue()
        {
            GcdIssueReprintOriginIssue = new HashSet<GcdIssueReprint>();
            GcdIssueReprintTargetIssue = new HashSet<GcdIssueReprint>();
            GcdReprintFromIssue = new HashSet<GcdReprintFromIssue>();
            GcdReprintToIssue = new HashSet<GcdReprintToIssue>();
            GcdSeriesFirstIssue = new HashSet<GcdSeries>();
            GcdSeriesLastIssue = new HashSet<GcdSeries>();
            GcdSeriesBondOriginIssue = new HashSet<GcdSeriesBond>();
            GcdSeriesBondTargetIssue = new HashSet<GcdSeriesBond>();
            GcdStory = new HashSet<GcdStory>();
        }

        public int Id { get; set; }
        public string Number { get; set; }
        public string Volume { get; set; }
        public byte NoVolume { get; set; }
        public byte DisplayVolumeWithNumber { get; set; }
        public int SeriesId { get; set; }
        public int? IndiciaPublisherId { get; set; }
        public byte IndiciaPubNotPrinted { get; set; }
        public int? BrandId { get; set; }
        public byte NoBrand { get; set; }
        public string PublicationDate { get; set; }
        public string KeyDate { get; set; }
        public int SortCode { get; set; }
        public string Price { get; set; }
        public decimal? PageCount { get; set; }
        public byte PageCountUncertain { get; set; }
        public string IndiciaFrequency { get; set; }
        public byte NoIndiciaFrequency { get; set; }
        public string Editing { get; set; }
        public byte NoEditing { get; set; }
        public string Notes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public byte Reserved { get; set; }
        public byte Deleted { get; set; }
        public byte IsIndexed { get; set; }
        public string Isbn { get; set; }
        public string ValidIsbn { get; set; }
        public byte NoIsbn { get; set; }
        public int? VariantOfId { get; set; }
        public string VariantName { get; set; }
        public string Barcode { get; set; }
        public byte NoBarcode { get; set; }
        public string Title { get; set; }
        public byte NoTitle { get; set; }
        public string OnSaleDate { get; set; }
        public byte OnSaleDateUncertain { get; set; }
        public string Rating { get; set; }
        public byte NoRating { get; set; }

        public virtual ICollection<GcdIssueReprint> GcdIssueReprintOriginIssue { get; set; }
        public virtual ICollection<GcdIssueReprint> GcdIssueReprintTargetIssue { get; set; }
        public virtual ICollection<GcdReprintFromIssue> GcdReprintFromIssue { get; set; }
        public virtual ICollection<GcdReprintToIssue> GcdReprintToIssue { get; set; }
        public virtual ICollection<GcdSeries> GcdSeriesFirstIssue { get; set; }
        public virtual ICollection<GcdSeries> GcdSeriesLastIssue { get; set; }
        public virtual ICollection<GcdSeriesBond> GcdSeriesBondOriginIssue { get; set; }
        public virtual ICollection<GcdSeriesBond> GcdSeriesBondTargetIssue { get; set; }
        public virtual ICollection<GcdStory> GcdStory { get; set; }
        public virtual GcdBrand Brand { get; set; }
        public virtual GcdIndiciaPublisher IndiciaPublisher { get; set; }
        public virtual GcdSeries Series { get; set; }
        public virtual GcdIssue VariantOf { get; set; }
        public virtual ICollection<GcdIssue> InverseVariantOf { get; set; }
    }
}
