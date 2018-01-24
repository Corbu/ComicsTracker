using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdSeries
    {
        public GcdSeries()
        {
            GcdIssue = new HashSet<GcdIssue>();
            GcdSeriesBondOrigin = new HashSet<GcdSeriesBond>();
            GcdSeriesBondTarget = new HashSet<GcdSeriesBond>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string SortName { get; set; }
        public string Format { get; set; }
        public int YearBegan { get; set; }
        public byte YearBeganUncertain { get; set; }
        public int? YearEnded { get; set; }
        public byte YearEndedUncertain { get; set; }
        public string PublicationDates { get; set; }
        public int? FirstIssueId { get; set; }
        public int? LastIssueId { get; set; }
        public byte IsCurrent { get; set; }
        public int PublisherId { get; set; }
        public int CountryId { get; set; }
        public int LanguageId { get; set; }
        public string TrackingNotes { get; set; }
        public string Notes { get; set; }
        public string PublicationNotes { get; set; }
        public byte HasGallery { get; set; }
        public int? OpenReserve { get; set; }
        public int IssueCount { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public byte Reserved { get; set; }
        public byte Deleted { get; set; }
        public byte HasIndiciaFrequency { get; set; }
        public byte HasIsbn { get; set; }
        public byte HasBarcode { get; set; }
        public byte HasIssueTitle { get; set; }
        public byte HasVolume { get; set; }
        public byte IsComicsPublication { get; set; }
        public string Color { get; set; }
        public string Dimensions { get; set; }
        public string PaperStock { get; set; }
        public string Binding { get; set; }
        public string PublishingFormat { get; set; }
        public byte HasRating { get; set; }
        public int? PublicationTypeId { get; set; }
        public byte IsSingleton { get; set; }

        public virtual ICollection<GcdIssue> GcdIssue { get; set; }
        public virtual ICollection<GcdSeriesBond> GcdSeriesBondOrigin { get; set; }
        public virtual ICollection<GcdSeriesBond> GcdSeriesBondTarget { get; set; }
        public virtual StddataCountry Country { get; set; }
        public virtual GcdIssue FirstIssue { get; set; }
        public virtual StddataLanguage Language { get; set; }
        public virtual GcdIssue LastIssue { get; set; }
        public virtual GcdSeriesPublicationType PublicationType { get; set; }
        public virtual GcdPublisher Publisher { get; set; }
    }
}
