using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata;
using WalletWise.Models.ValueObjects;
using WalletWise.Models.ViewModels;

namespace WalletWise.Models.Entities;

public partial class Expense
{
    [Key]
    public int ExpenId { get; set; }

    public string ExpenUserId { get; set; }
    public decimal ExpenTotalAmount { get; set; }
    public int  ExpenCurrencyId{ get; set; }
    
    public string ExpenName { get; set; }

    public DateTime ExpenDate { get; set; }

    public int? ExpenTag1 { get; set; }

    public int? ExpenTag2 { get; set; }

    public int? ExpenTag3 { get; set; }

    public int? ExpenTag4 { get; set; }

    public int? ExpenTag5 { get; set; }

    public string ExpenLocation { get; set; }
    public DateTime ExpenModTimestamp { get; set; }
    public virtual Currency ExpenCurrencyNavigation { get; set; }
    public virtual Tag ExpenTag1Navigation { get; set; }
    public virtual Tag ExpenTag2Navigation { get; set; }
    public virtual Tag ExpenTag3Navigation { get; set; }
    public virtual Tag ExpenTag4Navigation { get; set; }
    public virtual Tag ExpenTag5Navigation { get; set; }
    public virtual ICollection<ExpenseDetail> ExpenseDetails { get; set; } = new List<ExpenseDetail>();

    public ExpenseViewModel FromEntity(Expense entity)
    {
        return new ExpenseViewModel()
        {
            Id = entity.ExpenId,
            IdUser = entity.ExpenUserId,
            Date =entity.ExpenDate,
            Amount = entity.ExpenTotalAmount,
            Currency=entity.ExpenCurrencyNavigation.CurrAcronym,
            Name = entity.ExpenName,
            Location = entity.ExpenLocation,
        };
    }
}
