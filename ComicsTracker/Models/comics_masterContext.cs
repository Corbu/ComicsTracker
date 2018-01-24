using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ComicsTracker.Models
{
    public partial class comics_masterContext : DbContext
    {
        public virtual DbSet<GcdBrand> GcdBrand { get; set; }
        public virtual DbSet<GcdBrandEmblemGroup> GcdBrandEmblemGroup { get; set; }
        public virtual DbSet<GcdBrandGroup> GcdBrandGroup { get; set; }
        public virtual DbSet<GcdBrandUse> GcdBrandUse { get; set; }
        public virtual DbSet<GcdIndiciaPublisher> GcdIndiciaPublisher { get; set; }
        public virtual DbSet<GcdIssue> GcdIssue { get; set; }
        public virtual DbSet<GcdIssueReprint> GcdIssueReprint { get; set; }
        public virtual DbSet<GcdPublisher> GcdPublisher { get; set; }
        public virtual DbSet<GcdReprint> GcdReprint { get; set; }
        public virtual DbSet<GcdReprintFromIssue> GcdReprintFromIssue { get; set; }
        public virtual DbSet<GcdReprintToIssue> GcdReprintToIssue { get; set; }
        public virtual DbSet<GcdSeries> GcdSeries { get; set; }
        public virtual DbSet<GcdSeriesBond> GcdSeriesBond { get; set; }
        public virtual DbSet<GcdSeriesBondType> GcdSeriesBondType { get; set; }
        public virtual DbSet<GcdSeriesPublicationType> GcdSeriesPublicationType { get; set; }
        public virtual DbSet<GcdStory> GcdStory { get; set; }
        public virtual DbSet<GcdStoryType> GcdStoryType { get; set; }
        public virtual DbSet<StddataCountry> StddataCountry { get; set; }
        public virtual DbSet<StddataLanguage> StddataLanguage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySQL(@"server=localhost;port=3306;user=root;password=_nTDI4Y8JYbJYmTEBTYQOEAN;database=comics-master");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GcdBrand>(entity =>
            {
                entity.ToTable("gcd_brand", "comics-master");

                entity.HasIndex(e => e.Deleted)
                    .HasName("deleted");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.ParentId)
                    .HasName("parent_id");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.YearBegan)
                    .HasName("year_began");

                entity.HasIndex(e => e.YearBeganUncertain)
                    .HasName("year_began_uncertain");

                entity.HasIndex(e => e.YearEndedUncertain)
                    .HasName("year_ended_uncertain");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IssueCount)
                    .HasColumnName("issue_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.YearBegan)
                    .HasColumnName("year_began")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearBeganUncertain)
                    .HasColumnName("year_began_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.YearEnded)
                    .HasColumnName("year_ended")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearEndedUncertain)
                    .HasColumnName("year_ended_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.GcdBrand)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("parent_id_refs_id_296ca0e2d5166db4");
            });

            modelBuilder.Entity<GcdBrandEmblemGroup>(entity =>
            {
                entity.ToTable("gcd_brand_emblem_group", "comics-master");

                entity.HasIndex(e => e.BrandId)
                    .HasName("gcd_brand_emblem_group_74876276");

                entity.HasIndex(e => e.BrandgroupId)
                    .HasName("gcd_brand_emblem_group_9eac909a");

                entity.HasIndex(e => new { e.BrandId, e.BrandgroupId })
                    .HasName("gcd_brand_emblem_group_brand_id_4dd3b49d7f79dbe3_uniq")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandgroupId)
                    .HasColumnName("brandgroup_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.GcdBrandEmblemGroup)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("brand_id_refs_id_499c2f828021a0a5");

                entity.HasOne(d => d.Brandgroup)
                    .WithMany(p => p.GcdBrandEmblemGroup)
                    .HasForeignKey(d => d.BrandgroupId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("brandgroup_id_refs_id_3d239edd15609953");
            });

            modelBuilder.Entity<GcdBrandGroup>(entity =>
            {
                entity.ToTable("gcd_brand_group", "comics-master");

                entity.HasIndex(e => e.Deleted)
                    .HasName("gcd_brand_group_6cc99b0b");

                entity.HasIndex(e => e.Name)
                    .HasName("gcd_brand_group_52094d6e");

                entity.HasIndex(e => e.ParentId)
                    .HasName("gcd_brand_group_63f17a16");

                entity.HasIndex(e => e.Reserved)
                    .HasName("gcd_brand_group_3b2a5c11");

                entity.HasIndex(e => e.YearBegan)
                    .HasName("gcd_brand_group_d4f3f470");

                entity.HasIndex(e => e.YearBeganUncertain)
                    .HasName("gcd_brand_group_b5b058a2");

                entity.HasIndex(e => e.YearEndedUncertain)
                    .HasName("gcd_brand_group_8c53af9d");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IssueCount)
                    .HasColumnName("issue_count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.YearBegan)
                    .HasColumnName("year_began")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearBeganUncertain)
                    .HasColumnName("year_began_uncertain")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.YearEnded)
                    .HasColumnName("year_ended")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearEndedUncertain)
                    .HasColumnName("year_ended_uncertain")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.GcdBrandGroup)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("parent_id_refs_id_37eff265bd014aa2");
            });

            modelBuilder.Entity<GcdBrandUse>(entity =>
            {
                entity.ToTable("gcd_brand_use", "comics-master");

                entity.HasIndex(e => e.EmblemId)
                    .HasName("gcd_brand_use_7c3d3954");

                entity.HasIndex(e => e.PublisherId)
                    .HasName("gcd_brand_use_22dd9c39");

                entity.HasIndex(e => e.Reserved)
                    .HasName("gcd_brand_use_3b2a5c11");

                entity.HasIndex(e => e.YearBegan)
                    .HasName("gcd_brand_use_d4f3f470");

                entity.HasIndex(e => e.YearBeganUncertain)
                    .HasName("gcd_brand_use_b5b058a2");

                entity.HasIndex(e => e.YearEndedUncertain)
                    .HasName("gcd_brand_use_8c53af9d");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasColumnType("date");

                entity.Property(e => e.EmblemId)
                    .HasColumnName("emblem_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("date");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.PublisherId)
                    .HasColumnName("publisher_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.YearBegan)
                    .HasColumnName("year_began")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearBeganUncertain)
                    .HasColumnName("year_began_uncertain")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.YearEnded)
                    .HasColumnName("year_ended")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearEndedUncertain)
                    .HasColumnName("year_ended_uncertain")
                    .HasColumnType("tinyint(1)");

                entity.HasOne(d => d.Emblem)
                    .WithMany(p => p.GcdBrandUse)
                    .HasForeignKey(d => d.EmblemId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("emblem_id_refs_id_66e921df4498a093");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.GcdBrandUse)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("publisher_id_refs_id_4bf8142e98fbb94c");
            });

            modelBuilder.Entity<GcdIndiciaPublisher>(entity =>
            {
                entity.ToTable("gcd_indicia_publisher", "comics-master");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id");

                entity.HasIndex(e => e.Deleted)
                    .HasName("deleted");

                entity.HasIndex(e => e.IsSurrogate)
                    .HasName("is_surrogate");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.ParentId)
                    .HasName("parent_id");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.YearBegan)
                    .HasName("year_began");

                entity.HasIndex(e => e.YearBeganUncertain)
                    .HasName("year_began_uncertain");

                entity.HasIndex(e => e.YearEndedUncertain)
                    .HasName("year_ended_uncertain");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created).HasColumnName("created");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsSurrogate)
                    .HasColumnName("is_surrogate")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IssueCount)
                    .HasColumnName("issue_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modified).HasColumnName("modified");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.YearBegan)
                    .HasColumnName("year_began")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearBeganUncertain)
                    .HasColumnName("year_began_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.YearEnded)
                    .HasColumnName("year_ended")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearEndedUncertain)
                    .HasColumnName("year_ended_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.GcdIndiciaPublisher)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_indicia_publisher_ibfk_2");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.GcdIndiciaPublisher)
                    .HasForeignKey(d => d.ParentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_indicia_publisher_ibfk_1");
            });

            modelBuilder.Entity<GcdIssue>(entity =>
            {
                entity.ToTable("gcd_issue", "comics-master");

                entity.HasIndex(e => e.Barcode)
                    .HasName("barcode");

                entity.HasIndex(e => e.BrandId)
                    .HasName("brand_id");

                entity.HasIndex(e => e.Deleted)
                    .HasName("deleted");

                entity.HasIndex(e => e.DisplayVolumeWithNumber)
                    .HasName("display_volume_with_number");

                entity.HasIndex(e => e.IndiciaPublisherId)
                    .HasName("indicia_publisher_id");

                entity.HasIndex(e => e.IsIndexed)
                    .HasName("is_indexed");

                entity.HasIndex(e => e.Isbn)
                    .HasName("isbn");

                entity.HasIndex(e => e.KeyDate)
                    .HasName("Key_Date");

                entity.HasIndex(e => e.Modified)
                    .HasName("Modified");

                entity.HasIndex(e => e.NoBrand)
                    .HasName("no_brand");

                entity.HasIndex(e => e.NoEditing)
                    .HasName("no_editing");

                entity.HasIndex(e => e.NoIndiciaFrequency)
                    .HasName("no_indicia_frequency");

                entity.HasIndex(e => e.NoIsbn)
                    .HasName("no_isbn");

                entity.HasIndex(e => e.NoRating)
                    .HasName("gcd_issue_ed4c6b73");

                entity.HasIndex(e => e.NoTitle)
                    .HasName("no_title");

                entity.HasIndex(e => e.NoVolume)
                    .HasName("no_volume");

                entity.HasIndex(e => e.Number)
                    .HasName("Issue");

                entity.HasIndex(e => e.OnSaleDate)
                    .HasName("on_sale_date");

                entity.HasIndex(e => e.Rating)
                    .HasName("gcd_issue_1a619ca6");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.SeriesId)
                    .HasName("SeriesID");

                entity.HasIndex(e => e.SortCode)
                    .HasName("sort_code");

                entity.HasIndex(e => e.Title)
                    .HasName("title");

                entity.HasIndex(e => e.ValidIsbn)
                    .HasName("valid_isbn");

                entity.HasIndex(e => e.VariantOfId)
                    .HasName("variant_of_id");

                entity.HasIndex(e => e.Volume)
                    .HasName("VolumeNum");

                entity.HasIndex(e => new { e.SeriesId, e.SortCode })
                    .HasName("series_id_sort_code")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Barcode)
                    .IsRequired()
                    .HasColumnName("barcode")
                    .HasColumnType("varchar(38)")
                    .HasMaxLength(38);

                entity.Property(e => e.BrandId)
                    .HasColumnName("brand_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DisplayVolumeWithNumber)
                    .HasColumnName("display_volume_with_number")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Editing)
                    .IsRequired()
                    .HasColumnName("editing")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.IndiciaFrequency)
                    .IsRequired()
                    .HasColumnName("indicia_frequency")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.IndiciaPubNotPrinted)
                    .HasColumnName("indicia_pub_not_printed")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IndiciaPublisherId)
                    .HasColumnName("indicia_publisher_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsIndexed)
                    .HasColumnName("is_indexed")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Isbn)
                    .IsRequired()
                    .HasColumnName("isbn")
                    .HasColumnType("varchar(32)")
                    .HasMaxLength(32);

                entity.Property(e => e.KeyDate)
                    .IsRequired()
                    .HasColumnName("key_date")
                    .HasColumnType("varchar(10)")
                    .HasMaxLength(10);

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.NoBarcode)
                    .HasColumnName("no_barcode")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoBrand)
                    .HasColumnName("no_brand")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.NoEditing)
                    .HasColumnName("no_editing")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoIndiciaFrequency)
                    .HasColumnName("no_indicia_frequency")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoIsbn)
                    .HasColumnName("no_isbn")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoRating)
                    .HasColumnName("no_rating")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.NoTitle)
                    .HasColumnName("no_title")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoVolume)
                    .HasColumnName("no_volume")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Number)
                    .IsRequired()
                    .HasColumnName("number")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.OnSaleDate)
                    .IsRequired()
                    .HasColumnName("on_sale_date")
                    .HasColumnType("varchar(10)")
                    .HasMaxLength(10);

                entity.Property(e => e.OnSaleDateUncertain)
                    .HasColumnName("on_sale_date_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PageCount)
                    .HasColumnName("page_count")
                    .HasColumnType("decimal(10,3)");

                entity.Property(e => e.PageCountUncertain)
                    .HasColumnName("page_count_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasColumnName("price")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.PublicationDate)
                    .IsRequired()
                    .HasColumnName("publication_date")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasColumnName("rating")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeriesId)
                    .HasColumnName("series_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SortCode)
                    .HasColumnName("sort_code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.ValidIsbn)
                    .IsRequired()
                    .HasColumnName("valid_isbn")
                    .HasColumnType("varchar(13)")
                    .HasMaxLength(13);

                entity.Property(e => e.VariantName)
                    .IsRequired()
                    .HasColumnName("variant_name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.VariantOfId)
                    .HasColumnName("variant_of_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Volume)
                    .IsRequired()
                    .HasColumnName("volume")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.GcdIssue)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("gcd_issue_ibfk_3");

                entity.HasOne(d => d.IndiciaPublisher)
                    .WithMany(p => p.GcdIssue)
                    .HasForeignKey(d => d.IndiciaPublisherId)
                    .HasConstraintName("gcd_issue_ibfk_2");

                entity.HasOne(d => d.Series)
                    .WithMany(p => p.GcdIssue)
                    .HasForeignKey(d => d.SeriesId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_issue_ibfk_1");

                entity.HasOne(d => d.VariantOf)
                    .WithMany(p => p.InverseVariantOf)
                    .HasForeignKey(d => d.VariantOfId)
                    .HasConstraintName("gcd_issue_ibfk_4");
            });

            modelBuilder.Entity<GcdIssueReprint>(entity =>
            {
                entity.ToTable("gcd_issue_reprint", "comics-master");

                entity.HasIndex(e => e.OriginIssueId)
                    .HasName("issue_from");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.TargetIssueId)
                    .HasName("issue_to");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.OriginIssueId)
                    .HasColumnName("origin_issue_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetIssueId)
                    .HasColumnName("target_issue_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.OriginIssue)
                    .WithMany(p => p.GcdIssueReprintOriginIssue)
                    .HasForeignKey(d => d.OriginIssueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_issue_reprint_ibfk_1");

                entity.HasOne(d => d.TargetIssue)
                    .WithMany(p => p.GcdIssueReprintTargetIssue)
                    .HasForeignKey(d => d.TargetIssueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_issue_reprint_ibfk_2");
            });

            modelBuilder.Entity<GcdPublisher>(entity =>
            {
                entity.ToTable("gcd_publisher", "comics-master");

                entity.HasIndex(e => e.BrandCount)
                    .HasName("brand_count");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id");

                entity.HasIndex(e => e.Deleted)
                    .HasName("deleted");

                entity.HasIndex(e => e.IndiciaPublisherCount)
                    .HasName("indicia_publisher_count");

                entity.HasIndex(e => e.IsMaster)
                    .HasName("Master");

                entity.HasIndex(e => e.Name)
                    .HasName("PubName");

                entity.HasIndex(e => e.ParentId)
                    .HasName("ParentID");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.YearBegan)
                    .HasName("YearBegan");

                entity.HasIndex(e => e.YearBeganUncertain)
                    .HasName("year_began_uncertain");

                entity.HasIndex(e => e.YearEndedUncertain)
                    .HasName("year_ended_uncertain");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BrandCount)
                    .HasColumnName("brand_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ImprintCount)
                    .HasColumnName("imprint_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IndiciaPublisherCount)
                    .HasColumnName("indicia_publisher_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsMaster)
                    .HasColumnName("is_master")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IssueCount)
                    .HasColumnName("issue_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.ParentId)
                    .HasColumnName("parent_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SeriesCount)
                    .HasColumnName("series_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("url")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.YearBegan)
                    .HasColumnName("year_began")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearBeganUncertain)
                    .HasColumnName("year_began_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.YearEnded)
                    .HasColumnName("year_ended")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearEndedUncertain)
                    .HasColumnName("year_ended_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.GcdPublisher)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_publisher_ibfk_1");

                entity.HasOne(d => d.Parent)
                    .WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("gcd_publisher_ibfk_2");
            });

            modelBuilder.Entity<GcdReprint>(entity =>
            {
                entity.ToTable("gcd_reprint", "comics-master");

                entity.HasIndex(e => e.OriginId)
                    .HasName("reprint_from");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.TargetId)
                    .HasName("reprint_to");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.OriginId)
                    .HasColumnName("origin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetId)
                    .HasColumnName("target_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.GcdReprintOrigin)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_reprint_ibfk_1");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.GcdReprintTarget)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_reprint_ibfk_2");
            });

            modelBuilder.Entity<GcdReprintFromIssue>(entity =>
            {
                entity.ToTable("gcd_reprint_from_issue", "comics-master");

                entity.HasIndex(e => e.OriginIssueId)
                    .HasName("reprint_to_issue_from");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.TargetId)
                    .HasName("reprint_to_issue_to");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.OriginIssueId)
                    .HasColumnName("origin_issue_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetId)
                    .HasColumnName("target_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.OriginIssue)
                    .WithMany(p => p.GcdReprintFromIssue)
                    .HasForeignKey(d => d.OriginIssueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_reprint_from_issue_ibfk_1");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.GcdReprintFromIssue)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_reprint_from_issue_ibfk_2");
            });

            modelBuilder.Entity<GcdReprintToIssue>(entity =>
            {
                entity.ToTable("gcd_reprint_to_issue", "comics-master");

                entity.HasIndex(e => e.OriginId)
                    .HasName("reprint_to_issue_from");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.TargetIssueId)
                    .HasName("reprint_to_issue_to");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.OriginId)
                    .HasColumnName("origin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TargetIssueId)
                    .HasColumnName("target_issue_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.GcdReprintToIssue)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_reprint_to_issue_ibfk_1");

                entity.HasOne(d => d.TargetIssue)
                    .WithMany(p => p.GcdReprintToIssue)
                    .HasForeignKey(d => d.TargetIssueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_reprint_to_issue_ibfk_2");
            });

            modelBuilder.Entity<GcdSeries>(entity =>
            {
                entity.ToTable("gcd_series", "comics-master");

                entity.HasIndex(e => e.CountryId)
                    .HasName("country_id");

                entity.HasIndex(e => e.Deleted)
                    .HasName("deleted");

                entity.HasIndex(e => e.FirstIssueId)
                    .HasName("first_issue_id");

                entity.HasIndex(e => e.HasGallery)
                    .HasName("HasGallery");

                entity.HasIndex(e => e.IsCurrent)
                    .HasName("is_current");

                entity.HasIndex(e => e.LanguageId)
                    .HasName("language_id");

                entity.HasIndex(e => e.LastIssueId)
                    .HasName("last_issue_id");

                entity.HasIndex(e => e.Name)
                    .HasName("Bk_Name");

                entity.HasIndex(e => e.PublicationTypeId)
                    .HasName("gcd_series_49a7a4e1");

                entity.HasIndex(e => e.PublisherId)
                    .HasName("PubID");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.SortName)
                    .HasName("sort_name");

                entity.HasIndex(e => e.YearBegan)
                    .HasName("Yr_Began");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Binding)
                    .IsRequired()
                    .HasColumnName("binding")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.CountryId)
                    .HasColumnName("country_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Dimensions)
                    .IsRequired()
                    .HasColumnName("dimensions")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.FirstIssueId)
                    .HasColumnName("first_issue_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Format)
                    .IsRequired()
                    .HasColumnName("format")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.HasBarcode)
                    .HasColumnName("has_barcode")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.HasGallery)
                    .HasColumnName("has_gallery")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HasIndiciaFrequency)
                    .HasColumnName("has_indicia_frequency")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.HasIsbn)
                    .HasColumnName("has_isbn")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.HasIssueTitle)
                    .HasColumnName("has_issue_title")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.HasRating)
                    .HasColumnName("has_rating")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.HasVolume)
                    .HasColumnName("has_volume")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsComicsPublication)
                    .HasColumnName("is_comics_publication")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.IsCurrent)
                    .HasColumnName("is_current")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.IsSingleton)
                    .HasColumnName("is_singleton")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.IssueCount)
                    .HasColumnName("issue_count")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.LanguageId)
                    .HasColumnName("language_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LastIssueId)
                    .HasColumnName("last_issue_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.OpenReserve)
                    .HasColumnName("open_reserve")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaperStock)
                    .IsRequired()
                    .HasColumnName("paper_stock")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.PublicationDates)
                    .IsRequired()
                    .HasColumnName("publication_dates")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.PublicationNotes)
                    .IsRequired()
                    .HasColumnName("publication_notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.PublicationTypeId)
                    .HasColumnName("publication_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PublisherId)
                    .HasColumnName("publisher_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PublishingFormat)
                    .IsRequired()
                    .HasColumnName("publishing_format")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SortName)
                    .IsRequired()
                    .HasColumnName("sort_name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.TrackingNotes)
                    .IsRequired()
                    .HasColumnName("tracking_notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.YearBegan)
                    .HasColumnName("year_began")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearBeganUncertain)
                    .HasColumnName("year_began_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.YearEnded)
                    .HasColumnName("year_ended")
                    .HasColumnType("int(11)");

                entity.Property(e => e.YearEndedUncertain)
                    .HasColumnName("year_ended_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.GcdSeries)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_series_ibfk_3");

                entity.HasOne(d => d.FirstIssue)
                    .WithMany(p => p.GcdSeriesFirstIssue)
                    .HasForeignKey(d => d.FirstIssueId)
                    .HasConstraintName("gcd_series_ibfk_5");

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.GcdSeries)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_series_ibfk_4");

                entity.HasOne(d => d.LastIssue)
                    .WithMany(p => p.GcdSeriesLastIssue)
                    .HasForeignKey(d => d.LastIssueId)
                    .HasConstraintName("gcd_series_ibfk_6");

                entity.HasOne(d => d.PublicationType)
                    .WithMany(p => p.GcdSeries)
                    .HasForeignKey(d => d.PublicationTypeId)
                    .HasConstraintName("publication_type_id_refs_id_2c468df7974b9efa");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.GcdSeries)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_series_ibfk_2");
            });

            modelBuilder.Entity<GcdSeriesBond>(entity =>
            {
                entity.ToTable("gcd_series_bond", "comics-master");

                entity.HasIndex(e => e.BondTypeId)
                    .HasName("gcd_series_bond_1c107711");

                entity.HasIndex(e => e.OriginId)
                    .HasName("gcd_series_bond_bd654448");

                entity.HasIndex(e => e.OriginIssueId)
                    .HasName("gcd_series_bond_22a369b6");

                entity.HasIndex(e => e.Reserved)
                    .HasName("gcd_series_bond_3b2a5c11");

                entity.HasIndex(e => e.TargetId)
                    .HasName("gcd_series_bond_9358c897");

                entity.HasIndex(e => e.TargetIssueId)
                    .HasName("gcd_series_bond_b219039");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.BondTypeId)
                    .HasColumnName("bond_type_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.OriginId)
                    .HasColumnName("origin_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.OriginIssueId)
                    .HasColumnName("origin_issue_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)");

                entity.Property(e => e.TargetId)
                    .HasColumnName("target_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TargetIssueId)
                    .HasColumnName("target_issue_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.BondType)
                    .WithMany(p => p.GcdSeriesBond)
                    .HasForeignKey(d => d.BondTypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("bond_type_id_refs_id_74608925967dca7d");

                entity.HasOne(d => d.Origin)
                    .WithMany(p => p.GcdSeriesBondOrigin)
                    .HasForeignKey(d => d.OriginId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("origin_id_refs_id_2e5ee5bcc36327a6");

                entity.HasOne(d => d.OriginIssue)
                    .WithMany(p => p.GcdSeriesBondOriginIssue)
                    .HasForeignKey(d => d.OriginIssueId)
                    .HasConstraintName("origin_issue_id_refs_id_14846e21180392d7");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.GcdSeriesBondTarget)
                    .HasForeignKey(d => d.TargetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("target_id_refs_id_2e5ee5bcc36327a6");

                entity.HasOne(d => d.TargetIssue)
                    .WithMany(p => p.GcdSeriesBondTargetIssue)
                    .HasForeignKey(d => d.TargetIssueId)
                    .HasConstraintName("target_issue_id_refs_id_14846e21180392d7");
            });

            modelBuilder.Entity<GcdSeriesBondType>(entity =>
            {
                entity.ToTable("gcd_series_bond_type", "comics-master");

                entity.HasIndex(e => e.Name)
                    .HasName("gcd_series_bond_type_52094d6e");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);
            });

            modelBuilder.Entity<GcdSeriesPublicationType>(entity =>
            {
                entity.ToTable("gcd_series_publication_type", "comics-master");

                entity.HasIndex(e => e.Name)
                    .HasName("gcd_series_publication_type_52094d6e");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);
            });

            modelBuilder.Entity<GcdStory>(entity =>
            {
                entity.ToTable("gcd_story", "comics-master");

                entity.HasIndex(e => e.Deleted)
                    .HasName("deleted");

                entity.HasIndex(e => e.IssueId)
                    .HasName("IssueID");

                entity.HasIndex(e => e.Modified)
                    .HasName("Modified");

                entity.HasIndex(e => e.NoColors)
                    .HasName("no_colors");

                entity.HasIndex(e => e.NoEditing)
                    .HasName("no_editing");

                entity.HasIndex(e => e.NoInks)
                    .HasName("no_inks");

                entity.HasIndex(e => e.NoLetters)
                    .HasName("no_letters");

                entity.HasIndex(e => e.NoPencils)
                    .HasName("no_pencils");

                entity.HasIndex(e => e.NoScript)
                    .HasName("no_script");

                entity.HasIndex(e => e.PageCount)
                    .HasName("Pg_Cnt");

                entity.HasIndex(e => e.PageCountUncertain)
                    .HasName("page_count_uncertain");

                entity.HasIndex(e => e.Reserved)
                    .HasName("reserved");

                entity.HasIndex(e => e.TitleInferred)
                    .HasName("title_inferred");

                entity.HasIndex(e => e.TypeId)
                    .HasName("type_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Characters)
                    .IsRequired()
                    .HasColumnName("characters")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Colors)
                    .IsRequired()
                    .HasColumnName("colors")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.Deleted)
                    .HasColumnName("deleted")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Editing)
                    .IsRequired()
                    .HasColumnName("editing")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Feature)
                    .IsRequired()
                    .HasColumnName("feature")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Genre)
                    .IsRequired()
                    .HasColumnName("genre")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.Inks)
                    .IsRequired()
                    .HasColumnName("inks")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.IssueId)
                    .HasColumnName("issue_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.JobNumber)
                    .IsRequired()
                    .HasColumnName("job_number")
                    .HasColumnType("varchar(25)")
                    .HasMaxLength(25);

                entity.Property(e => e.Letters)
                    .IsRequired()
                    .HasColumnName("letters")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasDefaultValueSql("1901-01-01 00:00:00");

                entity.Property(e => e.NoColors)
                    .HasColumnName("no_colors")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoEditing)
                    .HasColumnName("no_editing")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoInks)
                    .HasColumnName("no_inks")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoLetters)
                    .HasColumnName("no_letters")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoPencils)
                    .HasColumnName("no_pencils")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NoScript)
                    .HasColumnName("no_script")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.PageCount)
                    .HasColumnName("page_count")
                    .HasColumnType("decimal(10,3)");

                entity.Property(e => e.PageCountUncertain)
                    .HasColumnName("page_count_uncertain")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Pencils)
                    .IsRequired()
                    .HasColumnName("pencils")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.ReprintNotes)
                    .IsRequired()
                    .HasColumnName("reprint_notes")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Reserved)
                    .HasColumnName("reserved")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Script)
                    .IsRequired()
                    .HasColumnName("script")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.SequenceNumber)
                    .HasColumnName("sequence_number")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Synopsis)
                    .IsRequired()
                    .HasColumnName("synopsis")
                    .HasColumnType("longtext")
                    .HasMaxLength(-1);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.TitleInferred)
                    .HasColumnName("title_inferred")
                    .HasColumnType("tinyint(1)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TypeId)
                    .HasColumnName("type_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Issue)
                    .WithMany(p => p.GcdStory)
                    .HasForeignKey(d => d.IssueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_story_ibfk_1");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GcdStory)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("gcd_story_ibfk_2");
            });

            modelBuilder.Entity<GcdStoryType>(entity =>
            {
                entity.ToTable("gcd_story_type", "comics-master");

                entity.HasIndex(e => e.Name)
                    .HasName("name")
                    .IsUnique();

                entity.HasIndex(e => e.SortCode)
                    .HasName("sort_code")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50);

                entity.Property(e => e.SortCode)
                    .HasColumnName("sort_code")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<StddataCountry>(entity =>
            {
                entity.ToTable("stddata_country", "comics-master");

                entity.HasIndex(e => e.Code)
                    .HasName("code_2")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("country");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(10)")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<StddataLanguage>(entity =>
            {
                entity.ToTable("stddata_language", "comics-master");

                entity.HasIndex(e => e.Code)
                    .HasName("code_2")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("language");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasColumnName("code")
                    .HasColumnType("varchar(10)")
                    .HasMaxLength(10);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);

                entity.Property(e => e.NativeName)
                    .IsRequired()
                    .HasColumnName("native_name")
                    .HasColumnType("varchar(255)")
                    .HasMaxLength(255);
            });
        }
    }
}