﻿// <auto-generated />
using System;
using JobPortalApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobPortalApplication.Migrations
{
    [DbContext(typeof(HireMeNowDbContext))]
    [Migration("20230707091312_inital3")]
    partial class inital3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobPortalApplication.Models.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<DateTime?>("AppliedDate")
                        .HasColumnType("date");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Applicat__3214EC07A0456D4C");

                    b.HasIndex("CompanyId");

                    b.HasIndex("JobId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("About")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Logo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Mission")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Vision")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Website")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Companie__3214EC075C9ACB91");

                    b.HasIndex(new[] { "Email" }, "UQ__Companie__A9D10534E9BC3D4E")
                        .IsUnique();

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Experience", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Company")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Duration")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("JobTitle")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Year")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Experien__3214EC077278D626");

                    b.HasIndex("UserId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Interview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<Guid?>("JobId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("JobseekerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<TimeSpan?>("Time")
                        .HasColumnType("time");

                    b.HasKey("Id")
                        .HasName("PK__Intervie__3214EC070182B074");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("JobId");

                    b.HasIndex("JobseekerId");

                    b.ToTable("Interviews");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Job", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<int?>("AppliedCount")
                        .HasColumnType("int");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Experience")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("JobType")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Responsibilities")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Salary")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TypeOfWorkPlace")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("VacanciesCount")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Jobs__3214EC07024D6053");

                    b.HasIndex("CompanyId");

                    b.HasIndex("CreatedBy");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Qualification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Mark")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("University")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("YearOfPassout")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Qualific__3214EC07ABC132FC");

                    b.HasIndex("UserId");

                    b.ToTable("Qualifications");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id")
                        .HasName("PK__Skills__3214EC0722774215");

                    b.HasIndex("UserId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("JobPortalApplication.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(newid())");

                    b.Property<string>("About")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("date");

                    b.Property<string>("Designation")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Image")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Role")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Users__3214EC07DCEC237A");

                    b.HasIndex("CompanyId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "UQ__Users__A9D105340BB73107")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Application", b =>
                {
                    b.HasOne("JobPortalApplication.Models.Company", "Company")
                        .WithMany("Applications")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK__Applicati__CompanyId__32E0915F");

                    b.HasOne("JobPortalApplication.Models.Job", "Job")
                        .WithMany("Applications")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__Applicati__JobId__33D4B598");

                    b.HasOne("JobPortalApplication.Models.User", "User")
                        .WithMany("Applications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Applicati__UserI__32E0915F");

                    b.Navigation("Company");

                    b.Navigation("Job");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Experience", b =>
                {
                    b.HasOne("JobPortalApplication.Models.User", "User")
                        .WithMany("Experiences")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Experienc__UserI__37A5467C");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Interview", b =>
                {
                    b.HasOne("JobPortalApplication.Models.User", "CreatedByNavigation")
                        .WithMany("InterviewCreatedByNavigations")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__Interview__Creat__3D5E1FD2");

                    b.HasOne("JobPortalApplication.Models.Job", "Job")
                        .WithMany("Interviews")
                        .HasForeignKey("JobId")
                        .HasConstraintName("FK__Interview__JobId__3B75D760");

                    b.HasOne("JobPortalApplication.Models.User", "Jobseeker")
                        .WithMany("InterviewJobseekers")
                        .HasForeignKey("JobseekerId")
                        .HasConstraintName("FK__Interview__Jobse__3C69FB99");

                    b.Navigation("CreatedByNavigation");

                    b.Navigation("Job");

                    b.Navigation("Jobseeker");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Job", b =>
                {
                    b.HasOne("JobPortalApplication.Models.Company", "Company")
                        .WithMany("Jobs")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK__Jobs__CompanyId__2E1BDC42");

                    b.HasOne("JobPortalApplication.Models.User", "CreatedByNavigation")
                        .WithMany("Jobs")
                        .HasForeignKey("CreatedBy")
                        .HasConstraintName("FK__Jobs__CreatedBy__2F10007B");

                    b.Navigation("Company");

                    b.Navigation("CreatedByNavigation");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Qualification", b =>
                {
                    b.HasOne("JobPortalApplication.Models.User", "User")
                        .WithMany("Qualifications")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Qualifica__UserI__412EB0B6");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Skill", b =>
                {
                    b.HasOne("JobPortalApplication.Models.User", "User")
                        .WithMany("Skills")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Skills__UserId__44FF419A");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JobPortalApplication.Models.User", b =>
                {
                    b.HasOne("JobPortalApplication.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK__Users__CreatedDa__2A4B4B5E");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Company", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Jobs");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("JobPortalApplication.Models.Job", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("JobPortalApplication.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Experiences");

                    b.Navigation("InterviewCreatedByNavigations");

                    b.Navigation("InterviewJobseekers");

                    b.Navigation("Jobs");

                    b.Navigation("Qualifications");

                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}
