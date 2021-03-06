﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Contacts.Database;

namespace Contacts.Migrations
{
  [DbContext(typeof(AppDbContext))]
  partial class AppDbContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618

      modelBuilder
        .HasAnnotation("ProductVersion", "3.1.5")
        .HasAnnotation("Relational:MaxIdentifierLength", 64);

      modelBuilder.Entity("contacts_api.Models.Contact", b =>
      {
        b.Property<int>("Id")
          .ValueGeneratedOnAdd()
          .HasColumnType("int");

        b.Property<DateTime?>("BirthDate")
          .HasColumnType("datetime(6)");

        b.Property<DateTime>("CreatedAt")
          .HasColumnType("datetime(6)");

        b.Property<bool>("Favorite")
          .HasColumnType("tinyint(1)");

        b.Property<string>("FirstName")
          .IsRequired()
          .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
          .HasMaxLength(50);

        b.Property<string>("LastName")
          .IsRequired()
          .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
          .HasMaxLength(50);

        b.Property<string>("NickName")
          .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
          .HasMaxLength(50);

        b.Property<string>("Notes")
          .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
          .HasMaxLength(255);

        b.Property<string>("Organization")
          .HasColumnType("varchar(100) CHARACTER SET utf8mb4")
          .HasMaxLength(100);

        b.Property<string>("Role")
          .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
          .HasMaxLength(50);

        b.Property<DateTime>("UpdatedAt")
          .HasColumnType("datetime(6)");

        b.HasKey("Id");

        b.ToTable("Contacts");
      });

      modelBuilder.Entity("contacts_api.Models.Email", b =>
      {
        b.Property<int>("Id")
          .ValueGeneratedOnAdd()
          .HasColumnType("int");

        b.Property<int>("ContactId")
          .HasColumnType("int");

        b.Property<DateTime>("CreatedAt")
          .HasColumnType("datetime(6)");

        b.Property<string>("EmailAddress")
          .IsRequired()
          .HasColumnType("varchar(120) CHARACTER SET utf8mb4")
          .HasMaxLength(120);

        b.Property<DateTime>("UpdatedAt")
          .HasColumnType("datetime(6)");

        b.HasKey("Id");

        b.HasIndex("ContactId");

        b.ToTable("Emails");
      });

      modelBuilder.Entity("contacts_api.Models.Phone", b =>
      {
        b.Property<int>("Id")
          .ValueGeneratedOnAdd()
          .HasColumnType("int");

        b.Property<int>("ContactId")
          .HasColumnType("int");

        b.Property<DateTime>("CreatedAt")
          .HasColumnType("datetime(6)");

        b.Property<string>("PhoneNumber")
          .IsRequired()
          .HasColumnType("varchar(15) CHARACTER SET utf8mb4")
          .HasMaxLength(15);

        b.Property<DateTime>("UpdatedAt")
          .HasColumnType("datetime(6)");

        b.HasKey("Id");

        b.HasIndex("ContactId");

        b.ToTable("Phones");
      });

      modelBuilder.Entity("contacts_api.Models.Email", b =>
      {
        b.HasOne("contacts_api.Models.Contact", null)
          .WithMany("Emails")
          .HasForeignKey("ContactId")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();
      });

      modelBuilder.Entity("contacts_api.Models.Phone", b =>
      {
        b.HasOne("contacts_api.Models.Contact", null)
          .WithMany("Phones")
          .HasForeignKey("ContactId")
          .OnDelete(DeleteBehavior.Cascade)
          .IsRequired();
      });

#pragma warning restore 612, 618
    }
  }
}
