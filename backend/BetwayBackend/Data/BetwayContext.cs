using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendSolution.Models;

public partial class BetwayContext : DbContext
{
    public BetwayContext(DbContextOptions<BetwayContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Otptoken> Otptokens { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<UserLogin> UserLogins { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Address");

            entity.HasIndex(e => e.PersonId, "FK_Address_Person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Region)
                .HasMaxLength(50)
                .HasColumnName("region");
            entity.Property(e => e.StreetName)
                .HasMaxLength(100)
                .HasColumnName("streetName");
            entity.Property(e => e.StreetNumber).HasColumnName("streetNumber");

            entity.HasOne(d => d.Person).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_Address_Person");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Contact");

            entity.HasIndex(e => e.PersonId, "personId");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CellNumber).HasColumnName("cellNumber");
            entity.Property(e => e.EmailAddress)
                .HasMaxLength(100)
                .HasColumnName("emailAddress");
            entity.Property(e => e.PersonId).HasColumnName("personId");

            entity.HasOne(d => d.Person).WithMany(p => p.Contacts)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("contact_ibfk_1");
        });

        modelBuilder.Entity<Otptoken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("OTPToken");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.CreatedDateTime)
                .HasColumnType("datetime")
                .HasColumnName("createdDateTime");
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .HasColumnName("token");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Otptoken)
                .HasForeignKey<Otptoken>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("otptoken_ibfk_1");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Person");

            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .HasColumnName("gender");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .HasColumnName("surname");
        });

        modelBuilder.Entity<UserLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("UserLogin");

            entity.HasIndex(e => e.PersonId, "FK_user_Person");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.PersonId).HasColumnName("personId");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.UserLoginIdNavigation)
                .HasForeignKey<UserLogin>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userlogin_ibfk_1");

            entity.HasOne(d => d.Person).WithMany(p => p.UserLoginPeople)
                .HasForeignKey(d => d.PersonId)
                .HasConstraintName("FK_user_Person");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
