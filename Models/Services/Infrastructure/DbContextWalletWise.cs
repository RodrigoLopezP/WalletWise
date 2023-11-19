using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WalletWise.Models.Entities;
// using WalletWise.Models.Enums;
using WalletWise.Models.ValueObjects;

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

    public virtual DbSet<ExpenseDetail> ExpenseDetails { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }
    public virtual DbSet<Currency> Currencies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
    }
     protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
     {
        base.ConfigureConventions(configurationBuilder);
        // configurationBuilder.Properties<Currency>().HaveConversion<string>();
    }
  
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder); // https://stackoverflow.com/questions/39576176/is-base-onmodelcreatingmodelbuilder-necessary (no)

        // modelBuilder.Owned<Money>();

        modelBuilder
            .UseCollation("utf8mb4_0900_bin")
            .HasCharSet("utf8mb4");
        #region TABLE EXPENSES
          modelBuilder.Entity<Expense>(entity =>{

            entity.ToTable("expenses");
            entity.HasKey(e => e.ExpenId).HasName("PRIMARY");
            entity.HasIndex(e => e.ExpenTag1, "FK_tags_expenses1");
            entity.HasIndex(e => e.ExpenTag2, "FK_tags_expenses2");
            entity.HasIndex(e => e.ExpenTag3, "FK_tags_expenses3");
            entity.HasIndex(e => e.ExpenTag4, "FK_tags_expenses4");
            entity.HasIndex(e => e.ExpenTag5, "FK_tags_expenses5");

            entity.Property(e => e.ExpenId)
            .HasColumnName("expen_id");

            entity.Property(e => e.ExpenTotalAmount)
            .HasPrecision(7, 2)
            .HasColumnName("expen_total_amount");

            entity.Property(e => e.ExpenCurrencyId)
            .IsRequired()
            .HasColumnName("expen_curr_id");

            entity.Property(e => e.ExpenName)
            .HasMaxLength(100)
            .HasColumnName("expen_name");

            entity.Property(e => e.ExpenDate)
            .HasColumnType("date")
            .HasColumnName("expen_date");

            entity.Property(e => e.ExpenTag1).HasColumnName("expen_tag1");
            entity.Property(e => e.ExpenTag2).HasColumnName("expen_tag2");
            entity.Property(e => e.ExpenTag3).HasColumnName("expen_tag3");
            entity.Property(e => e.ExpenTag4).HasColumnName("expen_tag4");
            entity.Property(e => e.ExpenTag5).HasColumnName("expen_tag5");

            entity.Property(e => e.ExpenLocation)
            .HasMaxLength(100)
            .HasColumnName("expen_location");

            entity.Property(e => e.ExpenModTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("expen_mod_timestamp");

            entity.Property(e => e.ExpenUserId)
                .HasColumnType("text")
                .HasColumnName("expen_user_id");
            
            entity.HasIndex(e => e.ExpenCurrencyId, "FK_currency_expenses");
            entity.HasOne(d=>d.ExpenCurrencyNavigation).WithMany(p => p.CurrencyExpenseNavigations)
                .HasForeignKey(d=> d.ExpenCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_currency_expenses");

            entity.HasOne(d => d.ExpenTag1Navigation).WithMany(p => p.ExpenseExpenTag1Navigations)
                .HasForeignKey(d => d.ExpenTag1)
                .HasConstraintName("FK_tags_expenses1");

            entity.HasOne(d => d.ExpenTag2Navigation).WithMany(p => p.ExpenseExpenTag2Navigations)
                .HasForeignKey(d => d.ExpenTag2)
                .HasConstraintName("FK_tags_expenses2");

            entity.HasOne(d => d.ExpenTag3Navigation).WithMany(p => p.ExpenseExpenTag3Navigations)
                .HasForeignKey(d => d.ExpenTag3)
                .HasConstraintName("FK_tags_expenses3");

            entity.HasOne(d => d.ExpenTag4Navigation).WithMany(p => p.ExpenseExpenTag4Navigations)
                .HasForeignKey(d => d.ExpenTag4)
                .HasConstraintName("FK_tags_expenses4");

            entity.HasOne(d => d.ExpenTag5Navigation).WithMany(p => p.ExpenseExpenTag5Navigations)
                .HasForeignKey(d => d.ExpenTag5)
                .HasConstraintName("FK_tags_expenses5");
        });
          #endregion
        #region TABLE EXPENSE_DETAILS
          modelBuilder.Entity<ExpenseDetail>(entity =>
        {
             entity.ToTable("expense_details");
             entity.HasKey(e => e.ExdetId).HasName("PRIMARY");

            entity.Property(e => e.ExdetId)
               .HasColumnName("exdet_id");

            entity.Property(e => e.ExdetExpenId)
            .HasColumnName("exdet_expen_id");

            entity.Property(e => e.ExdetName)
                .HasMaxLength(100)
                .HasColumnName("exdet_name");

            entity.Property(e => e.ExdetAmount)
               .HasPrecision(7, 2)
               .HasColumnName("exdet_amount");

            entity.Property(e=>e.ExdetCurrencyId)
                .IsRequired()
                .HasColumnName("exdet_curr_id");

            entity.Property(e => e.ExdetModTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("exdet_mod_timestamp");

             entity.HasIndex(e => e.ExdetCurrencyId, "FK_currency_expense_details");
            entity.HasOne(d=>d.ExdetCurrencyNavigation)
                .WithMany(p => p.CurrencyExpensedetailNavigations)
                .HasForeignKey(d=> d.ExdetCurrencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_currency_expense_details");

             entity.HasIndex(e => e.ExdetExpenId, "FK_expenses_expense_details");
             entity.HasOne(d => d.ExdetExpen)
                .WithMany(p => p.ExpenseDetails)
                .HasForeignKey(d => d.ExdetExpenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_expenses_expense_details");
        });

        #endregion
        #region TABLE TAGS
        modelBuilder.Entity<Tag>(entity =>
      {
          entity.HasKey(e => e.TagId).HasName("PRIMARY");
          entity.ToTable("tags");


          entity.Property(e => e.TagId)
          .HasColumnName("tag_id");

          entity.Property(e => e.TagDescription)
              .HasMaxLength(500)
              .HasColumnName("tag_description");

          entity.Property(e => e.TagModTimestamp)
                .HasColumnType("datetime")
                .HasColumnName("tag_mod_timestamp");

          entity.Property(e => e.TagName)
              .HasMaxLength(100)
              .HasColumnName("tag_name");

          entity.Property(e => e.TagUserId)
              .HasColumnType("text")
              .HasColumnName("tag_user_id");
      });

        #endregion
        #region TABLE CURRENCY
        modelBuilder.Entity<Currency>(entity=>{
            entity.ToTable("currencies");
            entity.HasKey(e=> e.CurrId)
                .HasName("PRIMARY");

            entity.Property(e=>e.CurrId)
                .HasColumnName("curr_id");

            entity.Property(e=>e.CurrName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("curr_name");
                
            entity.Property(e=>e.CurrAcronym)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("curr_acronym");
        });
        #endregion
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
