using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class developperContext : DbContext
    {
        public virtual DbSet<Changeset> Changeset { get; set; }
        public virtual DbSet<Changesetfile> Changesetfile { get; set; }
        public virtual DbSet<Codereviewrequest> Codereviewrequest { get; set; }
        public virtual DbSet<Codereviewresponse> Codereviewresponse { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Developper> Developper { get; set; }
        public virtual DbSet<Direction> Direction { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Issue> Issue { get; set; }
        public virtual DbSet<Servicebuild> Servicebuild { get; set; }
        public virtual DbSet<Serviceinformation> Serviceinformation { get; set; }
        public virtual DbSet<Servicemetrics> Servicemetrics { get; set; }
        public virtual DbSet<Shelveset> Shelveset { get; set; }
        public virtual DbSet<Shelvesetfile> Shelvesetable { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Teamdirection> Teamdirection { get; set; }
        public virtual DbSet<Userteam> Userteam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
            optionsBuilder.UseMySql(@"Server=localhost;Port=3306;Database=developper;user id=root;password=root");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Changeset>(entity =>
            {
                entity.ToTable("changeset");

                entity.HasIndex(e => e.DevelopperId)
                    .HasName("DevelopperIDchangesets_idx");

                entity.Property(e => e.ChangesetId)
                    .HasColumnName("ChangesetID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Comment).HasColumnType("varchar(500)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DevelopperId)
                    .HasColumnName("DevelopperID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Developper)
                    .WithMany(p => p.Changeset)
                    .HasForeignKey(d => d.DevelopperId)
                    .HasConstraintName("DevelopperIDchangesets");
            });

            modelBuilder.Entity<Changesetfile>(entity =>
            {
                entity.HasKey(e => new { e.ChangesetId, e.FileId })
                    .HasName("PK_changesetfile");

                entity.ToTable("changesetfile");

                entity.HasIndex(e => e.FileId)
                    .HasName("fileIDchangesetfile_idx");

                entity.Property(e => e.ChangesetId)
                    .HasColumnName("changesetID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileId)
                    .HasColumnName("FileID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Changeset)
                    .WithMany(p => p.Changesetfile)
                    .HasForeignKey(d => d.ChangesetId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("changesetIDchangesetfile");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Changesetfile)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fileIDchangesetfile");
            });

            modelBuilder.Entity<Codereviewrequest>(entity =>
            {
                entity.ToTable("codereviewrequest");

                entity.HasIndex(e => e.ClosedBy)
                    .HasName("DevelopperIDclosedBy_idx");

                entity.HasIndex(e => e.CreatedBy)
                    .HasName("DevelopperIDcreatedBy_idx");

                entity.Property(e => e.CodeReviewRequestId)
                    .HasColumnName("CodeReviewRequestID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChangedDate).HasColumnType("datetime");

                entity.Property(e => e.ClosedBy).HasColumnType("int(11)");

                entity.Property(e => e.ClosedDate).HasColumnType("datetime");

                entity.Property(e => e.CodeReviewClosedStatus).HasColumnType("varchar(45)");

                entity.Property(e => e.CodeReviewContext).HasColumnType("varchar(50)");

                entity.Property(e => e.ContexteType).HasColumnType("varchar(45)");

                entity.Property(e => e.CreatedBy).HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.State).HasColumnType("varchar(45)");

                entity.Property(e => e.Title).HasColumnType("varchar(500)");

                entity.HasOne(d => d.ClosedByNavigation)
                    .WithMany(p => p.CodereviewrequestClosedByNavigation)
                    .HasForeignKey(d => d.ClosedBy)
                    .HasConstraintName("DevelopperIDclosedBy");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.CodereviewrequestCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("DevelopperIDcreatedBy");
            });

            modelBuilder.Entity<Codereviewresponse>(entity =>
            {
                entity.ToTable("codereviewresponse");

                entity.HasIndex(e => e.ClosedBy)
                    .HasName("DevelopperIDClosedby_idx");

                entity.HasIndex(e => e.ReviewedBy)
                    .HasName("DevelopperIDReviewedby_idx");

                entity.Property(e => e.CodeReviewResponseId)
                    .HasColumnName("CodeReviewResponseID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ChangedDate).HasColumnType("datetime");

                entity.Property(e => e.ClosedBy).HasColumnType("int(11)");

                entity.Property(e => e.ClosedDate).HasColumnType("datetime");

                entity.Property(e => e.ClosedStatus).HasColumnType("varchar(45)");

                entity.Property(e => e.CodeReviewRequestId)
                    .HasColumnName("CodeReviewRequestID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ReviewedBy).HasColumnType("int(11)");

                entity.Property(e => e.State).HasColumnType("varchar(45)");

                entity.Property(e => e.Title).HasColumnType("varchar(500)");

                entity.HasOne(d => d.ClosedByNavigation)
                    .WithMany(p => p.CodereviewresponseClosedByNavigation)
                    .HasForeignKey(d => d.ClosedBy)
                    .HasConstraintName("DevelopperIDClosedbyResponse");

                entity.HasOne(d => d.ReviewedByNavigation)
                    .WithMany(p => p.CodereviewresponseReviewedByNavigation)
                    .HasForeignKey(d => d.ReviewedBy)
                    .HasConstraintName("DevelopperIDReviewedby");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.HasIndex(e => e.CodeReviewRequestId)
                    .HasName("CodeRRequestIDcomments_idx");

                entity.HasIndex(e => e.DevelopperId)
                    .HasName("DevelopperIDcomments_idx");

                entity.HasIndex(e => e.FileId)
                    .HasName("FileIDcomments_idx");

                entity.Property(e => e.CommentId)
                    .HasColumnName("CommentID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CodeReviewRequestId)
                    .HasColumnName("CodeReviewRequestID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Content)
                    .HasColumnName("Comment")
                    .HasColumnType("varchar(10000)");

                entity.Property(e => e.DevelopperId)
                    .HasColumnName("DevelopperID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileId)
                    .HasColumnName("FileID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ParentId)
                    .HasColumnName("ParentID")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PublishDate).HasColumnType("datetime");

                entity.HasOne(d => d.CodeReviewRequest)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.CodeReviewRequestId)
                    .HasConstraintName("CodeRRequestIDcomments");

                entity.HasOne(d => d.Developper)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.DevelopperId)
                    .HasConstraintName("DevelopperIDcomments");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FileIDcomments");
            });

            modelBuilder.Entity<Developper>(entity =>
            {
                entity.ToTable("developper");

                entity.HasIndex(e => e.Name)
                    .HasName("Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.DevelopperId)
                    .HasColumnName("DevelopperID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email).HasColumnType("varchar(45)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Login).HasColumnType("varchar(45)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Direction>(entity =>
            {
                entity.ToTable("direction");

                entity.Property(e => e.DirectionId)
                    .HasColumnName("DirectionID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DirectionName).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.DevelopperId)
                    .HasName("DevelopperIDEvent_idx");

                entity.Property(e => e.EventId).HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("varchar(45)");

                entity.Property(e => e.DevelopperId).HasColumnType("int(11)");

                entity.HasOne(d => d.Developper)
                    .WithMany(p => p.Event)
                    .HasForeignKey(d => d.DevelopperId)
                    .HasConstraintName("DevelopperIDEvent");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("file");

                entity.HasIndex(e => e.FileKey)
                    .HasName("FileKey_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.ServiceId)
                    .HasName("ServiceIDfiles_idx");

                entity.Property(e => e.FileId)
                    .HasColumnName("FileID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileKey)
                    .IsRequired()
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Issue>(entity =>
            {
                entity.HasKey(e => new { e.IssueId, e.Type })
                    .HasName("PK_issue");

                entity.ToTable("issue");

                entity.HasIndex(e => e.DevelopperId)
                    .HasName("DevelopperIDissues_idx");

                entity.HasIndex(e => e.FileId)
                    .HasName("FileIDissues_idx");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("ServiceIdissues_idx");

                entity.Property(e => e.IssueId)
                    .HasColumnName("IssueID")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.Type).HasColumnType("varchar(45)");

                entity.Property(e => e.CreationDate).HasColumnType("datetime");

                entity.Property(e => e.DevelopperId)
                    .HasColumnName("DevelopperID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileId)
                    .HasColumnName("FileID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Line).HasColumnType("int(11)");

                entity.Property(e => e.Resolved)
                    .HasColumnType("varchar(45)")
                    .HasDefaultValueSql("False");

                entity.Property(e => e.RuleKey).HasColumnType("varchar(45)");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Severity).HasColumnType("varchar(45)");

                entity.Property(e => e.UpdateDate).HasColumnType("datetime");

                entity.HasOne(d => d.Developper)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.DevelopperId)
                    .HasConstraintName("DevelopperIDissues");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Issue)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FileIDissues");

                  

            });

            modelBuilder.Entity<Servicebuild>(entity =>
            {
                entity.HasKey(e => e.BuildName)
                    .HasName("PK_servicebuild");

                entity.ToTable("servicebuild");

                entity.HasIndex(e => e.DevelopperId)
                    .HasName("DevelopperIDbuilds_idx");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("ServiceID_idx");

                entity.Property(e => e.BuildName).HasColumnType("varchar(45)");

                entity.Property(e => e.DevelopperId)
                    .HasColumnName("DevelopperID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FinishTime).HasColumnType("datetime");

                entity.Property(e => e.IncompleteTests)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.NotApplicableTests)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PassedTests)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.Result).HasColumnType("varchar(45)");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.TotalTests)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.UnanalyzedTests)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("0");

                entity.HasOne(d => d.Developper)
                    .WithMany(p => p.Servicebuild)
                    .HasForeignKey(d => d.DevelopperId)
                    .HasConstraintName("DevelopperIDbuilds");
            });

            modelBuilder.Entity<Serviceinformation>(entity =>
            {
                entity.HasKey(e => new { e.ServiceId, e.ServiceName })
                    .HasName("PK_serviceinformation");

                entity.ToTable("serviceinformation");

                entity.HasIndex(e => e.DirectionTeamId)
                    .HasName("DirectionTeamIDserviceinformation_idx");

                entity.HasIndex(e => e.ServiceName)
                    .HasName("ServiceID")
                    .IsUnique();

                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ServiceName).HasColumnType("varchar(45)");

                entity.Property(e => e.DirectionTeamId)
                    .HasColumnName("DirectionTeamID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ServiceSonarKey).HasColumnType("varchar(45)");

                entity.Property(e => e.ServiceTfsKey).HasColumnType("varchar(45)");

                entity.HasOne(d => d.DirectionTeam)
                    .WithMany(p => p.Serviceinformation)
                    .HasForeignKey(d => d.DirectionTeamId)
                    .HasConstraintName("DirectionTeamIDserviceinformation");
            });

            modelBuilder.Entity<Servicemetrics>(entity =>
            {
                entity.HasKey(e => e.ServiceMetricId)
                    .HasName("PK_servicemetrics");

                entity.ToTable("servicemetrics");

                entity.HasIndex(e => e.ServiceId)
                    .HasName("ServiceID_idx");

                entity.Property(e => e.ServiceMetricId)
                    .HasColumnName("ServiceMetricID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Complexity).HasColumnType("int(11)");

                entity.Property(e => e.Coverage).HasColumnType("decimal(4,2)");

                entity.Property(e => e.Documentation).HasColumnType("decimal(4,2)");

                entity.Property(e => e.Duplication).HasColumnType("decimal(4,2)");

                entity.Property(e => e.InterrogationDate).HasColumnType("datetime");

                entity.Property(e => e.NumberBugs).HasColumnType("int(11)");

                entity.Property(e => e.NumberCodeSmells).HasColumnType("int(11)");

                entity.Property(e => e.NumberVulnerabilities).HasColumnType("int(11)");

                entity.Property(e => e.ServiceId)
                    .HasColumnName("ServiceID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ServiceProfile).HasColumnType("varchar(45)");

                entity.Property(e => e.Size).HasColumnType("int(11)");
            });

            modelBuilder.Entity<Shelveset>(entity =>
            {
                entity.ToTable("shelveset");

                entity.HasIndex(e => e.ShelvesetOwner)
                    .HasName("ShelvesetOwner_idx");

                entity.Property(e => e.ShelvesetId)
                    .HasColumnName("ShelvesetID")
                    .HasColumnType("int(11)");
                
                // ici j'ai modifié
                entity.Property(e => e.CodeReviewRequestID).HasColumnName("CodeReviewRequestID").HasColumnType("int(11)");


                entity.Property(e => e.Comment).HasColumnType("varchar(100)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ShelvesetName).HasColumnType("varchar(45)");

                entity.Property(e => e.ShelvesetOwner).HasColumnType("int(11)");

                entity.HasOne(d => d.ShelvesetOwnerNavigation)
                    .WithMany(p => p.Shelveset)
                    .HasForeignKey(d => d.ShelvesetOwner)
                    .HasConstraintName("ShelvesetOwner");
            });

            modelBuilder.Entity<Shelvesetfile>(entity =>
            {
                entity.HasKey(e => new { e.ShelevesetId, e.FileId })
                    .HasName("PK_shelvesetable");

                entity.ToTable("shelvesetable");

                entity.Property(e => e.ShelevesetId)
                    .HasColumnName("ShelevesetID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FileId)
                    .HasColumnName("FileID")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.TeamId)
                    .HasColumnName("TeamID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ManagerActiveDirectoryId)
                    .HasColumnName("ManagerActiveDirectoryID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TeamName).HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Teamdirection>(entity =>
            {
                entity.HasKey(e => e.DirectionTeamId)
                    .HasName("PK_teamdirection");

                entity.ToTable("teamdirection");

                entity.HasIndex(e => e.DirectionId)
                    .HasName("DirectionIDteamdirection_idx");

                entity.Property(e => e.DirectionTeamId)
                    .HasColumnName("DirectionTeamID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DirectionId)
                    .HasColumnName("DirectionID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DirectionteamName).HasColumnType("varchar(45)");

                entity.HasOne(d => d.Direction)
                    .WithMany(p => p.Teamdirection)
                    .HasForeignKey(d => d.DirectionId)
                    .HasConstraintName("DirectionIDteamdirection");
            });

            modelBuilder.Entity<Userteam>(entity =>
            {
                entity.HasKey(e => new { e.TeamId, e.DevelopperId })
                    .HasName("PK_userteam");

                entity.ToTable("userteam");

                entity.HasIndex(e => e.DevelopperId)
                    .HasName("DevelopperIDUsersTeams_idx");

                entity.HasIndex(e => e.TeamId)
                    .HasName("TeamIDUsersTeams_idx");

                entity.Property(e => e.TeamId)
                    .HasColumnName("TeamID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DevelopperId)
                    .HasColumnName("DevelopperID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Developper)
                    .WithMany(p => p.Userteam)
                    .HasForeignKey(d => d.DevelopperId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("DevelopperIDUsersTeams");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.Userteam)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("TeamIDUsersTeams");
            });
        }
    }
}