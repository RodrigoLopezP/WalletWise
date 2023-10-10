using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WalletWise.Models.Entities;

namespace WalletWise.Models.Services.Infrastructure;

public partial class DbContextWalletWise : DbContext
{
    public DbContextWalletWise()
    {
    }

    public DbContextWalletWise(DbContextOptions<DbContextWalletWise> options)
        : base(options)
    {
    }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_bin")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenId).HasName("PRIMARY");

            entity.ToTable("expenses");
            //PK Expense
            entity.Property(e => e.ExpenId)
                .HasColumnName("expen_ID");
            entity.Property(e => e.ExpenCurrency)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("expen_currency");
            entity.Property(e => e.ExpenDate)
                .HasColumnType("datetime")
                .HasColumnName("expen_date");
            entity.Property(e => e.ExpenLocation)
                .HasMaxLength(100)
                .HasColumnName("expen_location");
            entity.Property(e => e.ExpenName)
                .HasMaxLength(100)
                .HasColumnName("expen_name");
            entity.Property(e => e.ExpenTag1).HasColumnName("expen_tag1");
            entity.Property(e => e.ExpenTag2).HasColumnName("expen_tag2");
            entity.Property(e => e.ExpenTag3).HasColumnName("expen_tag3");
            entity.Property(e => e.ExpenTag4).HasColumnName("expen_tag4");
            entity.Property(e => e.ExpenTag5).HasColumnName("expen_tag5");
            entity.Property(e => e.ExpenTotalAmount)
                .HasPrecision(7, 2)
                .HasColumnName("expen_total_amount");
            entity.Property(e => e.ExpenUserId)
                .HasColumnType("text")
                .HasColumnName("expen_user_ID");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PRIMARY");

            entity.ToTable("tags");

            entity.Property(e => e.TagId)
                .ValueGeneratedOnAdd()
                .HasColumnName("tag_id");
            entity.Property(e => e.TagDescription)
                .HasMaxLength(500)
                .HasColumnName("tag_description");
            entity.Property(e => e.TagIsPublic).HasColumnName("tag_is_public");
            entity.Property(e => e.TagName)
                .HasMaxLength(100)
                .HasColumnName("tag_name");
            entity.Property(e => e.TagUserId)
                .HasColumnType("text")
                .HasColumnName("tag_user_id");

            entity.HasOne(d => d.TagNavigation).WithOne(p => p.Tag)
                .HasForeignKey<Tag>(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tags_expenses1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
