using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class dbcontext : DbContext
{
    public dbcontext()
    {
    }

    public dbcontext(DbContextOptions<dbcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<ApartmentDetail> ApartmentDetails { get; set; }

    public virtual DbSet<Application> Applications { get; set; }

    public virtual DbSet<Assessment> Assessments { get; set; }

    public virtual DbSet<Assessor> Assessors { get; set; }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"F:\\תיקייה כללית חדש\\שנה ב תשפה\\קבוצה א\\תלמידות\\..Ayali Nechami Miri\\ourData\\ourAssessing.mdf\";Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ApartmentDetail>(entity =>
        {
            entity.HasKey(e => e.ApartmentId).HasName("PK__apartmen__AA9EDC6401D86045");

            entity.ToTable("apartmentDetails");

            entity.Property(e => e.ApartmentId)
                .ValueGeneratedNever()
                .HasColumnName("apartmentId");
            entity.Property(e => e.AirDirections).HasColumnName("airDirections");
            entity.Property(e => e.ApartmentAddress)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("apartmentAddress");
            entity.Property(e => e.ApartmentCity)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("apartmentCity");
            entity.Property(e => e.ApartmentSize).HasColumnName("apartmentSize");
            entity.Property(e => e.CustomerId)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerId");
            entity.Property(e => e.Directions)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("directions");
            entity.Property(e => e.Elevator).HasColumnName("elevator");
            entity.Property(e => e.Floor).HasColumnName("floor");

            entity.HasOne(d => d.Apartment).WithOne(p => p.ApartmentDetail)
                .HasForeignKey<ApartmentDetail>(d => d.ApartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__apartment__apart__30C33EC3");

            entity.HasOne(d => d.Customer).WithMany(p => p.ApartmentDetails)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__apartment__custo__37703C52");
        });

        modelBuilder.Entity<Application>(entity =>
        {
            entity.HasKey(e => e.ApplicationId).HasName("PK__tmp_ms_x__79FDB1CFCC3E94DF");

            entity.ToTable("applications");

            entity.Property(e => e.ApplicationId)
                .ValueGeneratedNever()
                .HasColumnName("applicationId");
            entity.Property(e => e.ApplicationDate)
                .HasColumnType("datetime")
                .HasColumnName("applicationDate");
            entity.Property(e => e.ApplicationStatus).HasColumnName("applicationStatus");
            entity.Property(e => e.AssessorId)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorId");
            entity.Property(e => e.LastApplicationDate)
                .HasColumnType("datetime")
                .HasColumnName("lastApplicationDate");

            entity.HasOne(d => d.Assessor).WithMany(p => p.Applications)
                .HasForeignKey(d => d.AssessorId)
                .HasConstraintName("FK__applicati__asses__2FCF1A8A");
        });

        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(e => e.AssessmentId).HasName("PK__assessme__C77427720C31A60B");

            entity.ToTable("assessments");

            entity.Property(e => e.AssessmentId)
                .ValueGeneratedNever()
                .HasColumnName("assessmentId");
            entity.Property(e => e.AcquisionPrice).HasColumnName("acquisionPrice");
            entity.Property(e => e.AssessmentGoal)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessmentGoal");
            entity.Property(e => e.Block)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("block");
            entity.Property(e => e.BuildingPermit)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("buildingPermit");
            entity.Property(e => e.ConstructionYear)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("constructionYear");
            entity.Property(e => e.IrregularitiesBuilding)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("irregularitiesBuilding");
            entity.Property(e => e.LegalState)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("legalState");
            entity.Property(e => e.Plot)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("plot");
            entity.Property(e => e.SubPlot)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("subPlot");

            entity.HasOne(d => d.AssessmentNavigation).WithOne(p => p.Assessment)
                .HasForeignKey<Assessment>(d => d.AssessmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__assessmen__asses__31B762FC");
        });

        modelBuilder.Entity<Assessor>(entity =>
        {
            entity.HasKey(e => e.AssessorId).HasName("PK__tmp_ms_x__B9CF041749A0AA51");

            entity.ToTable("assessors");

            entity.Property(e => e.AssessorId)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorId");
            entity.Property(e => e.AssessorAddress)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorAddress");
            entity.Property(e => e.AssessorCity)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorCity");
            entity.Property(e => e.AssessorEmail)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorEmail");
            entity.Property(e => e.AssessorFirstName)
                .HasMaxLength(15)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorFirstName");
            entity.Property(e => e.AssessorLastName)
                .HasMaxLength(15)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorLastName");
            entity.Property(e => e.AssessorPhone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("assessorPhone");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.IsManager).HasColumnName("isManager");
            entity.Property(e => e.NumOfCustomers)
                .HasDefaultValueSql("((0))")
                .HasColumnName("numOfCustomers");
            entity.Property(e => e.Seniority).HasColumnName("seniority");
        });

        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.ChatId).HasName("PK__chats__826385ADBA38ADD6");

            entity.ToTable("chats");

            entity.Property(e => e.ChatId)
                .ValueGeneratedNever()
                .HasColumnName("chatId");
            entity.Property(e => e.ApplicationId).HasColumnName("applicationId");
            entity.Property(e => e.From)
                .HasMaxLength(1)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("from");
            entity.Property(e => e.Information)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("information");
            entity.Property(e => e.Read)
                .HasDefaultValueSql("((0))")
                .HasColumnName("read");
            entity.Property(e => e.SendDate)
                .HasColumnType("datetime")
                .HasColumnName("sendDate");
            entity.Property(e => e.To)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("to");

            entity.HasOne(d => d.Application).WithMany(p => p.Chats)
                .HasForeignKey(d => d.ApplicationId)
                .HasConstraintName("FK__chats__applicati__73852659");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__tmp_ms_x__B611CB7DFBAE1FC3");

            entity.ToTable("customers");

            entity.Property(e => e.CustomerId)
                .HasMaxLength(9)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerId");
            entity.Property(e => e.CustomerAddress)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerAddress");
            entity.Property(e => e.CustomerCity)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerCity");
            entity.Property(e => e.CustomerEmail)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerEmail");
            entity.Property(e => e.CustomerFirstName)
                .HasMaxLength(15)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerFirstName");
            entity.Property(e => e.CustomerLastName)
                .HasMaxLength(15)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerLastName");
            entity.Property(e => e.CustomerPhone)
                .HasMaxLength(10)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("customerPhone");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__statuses__36257A18DBB650F0");

            entity.ToTable("statuses");

            entity.Property(e => e.StatusId).HasColumnName("statusId");
            entity.Property(e => e.StatusDescribtion)
                .HasMaxLength(20)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnName("statusDescribtion");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
