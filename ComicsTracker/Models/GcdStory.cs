using System;
using System.Collections.Generic;

namespace ComicsTracker.Models
{
    public partial class GcdStory
    {
        public GcdStory()
        {
            GcdReprintOrigin = new HashSet<GcdReprint>();
            GcdReprintTarget = new HashSet<GcdReprint>();
            GcdReprintFromIssue = new HashSet<GcdReprintFromIssue>();
            GcdReprintToIssue = new HashSet<GcdReprintToIssue>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public byte TitleInferred { get; set; }
        public string Feature { get; set; }
        public int SequenceNumber { get; set; }
        public decimal? PageCount { get; set; }
        public int IssueId { get; set; }
        public string Script { get; set; }
        public string Pencils { get; set; }
        public string Inks { get; set; }
        public string Colors { get; set; }
        public string Letters { get; set; }
        public string Editing { get; set; }
        public string Genre { get; set; }
        public string Characters { get; set; }
        public string Synopsis { get; set; }
        public string ReprintNotes { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
        public string Notes { get; set; }
        public byte NoScript { get; set; }
        public byte NoPencils { get; set; }
        public byte NoInks { get; set; }
        public byte NoColors { get; set; }
        public byte NoLetters { get; set; }
        public byte NoEditing { get; set; }
        public byte PageCountUncertain { get; set; }
        public int TypeId { get; set; }
        public string JobNumber { get; set; }
        public byte Reserved { get; set; }
        public byte Deleted { get; set; }

        public virtual ICollection<GcdReprint> GcdReprintOrigin { get; set; }
        public virtual ICollection<GcdReprint> GcdReprintTarget { get; set; }
        public virtual ICollection<GcdReprintFromIssue> GcdReprintFromIssue { get; set; }
        public virtual ICollection<GcdReprintToIssue> GcdReprintToIssue { get; set; }
        public virtual GcdIssue Issue { get; set; }
        public virtual GcdStoryType Type { get; set; }
    }
}
