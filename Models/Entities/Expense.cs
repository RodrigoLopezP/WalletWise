using System;
using System.Collections.Generic;
using WalletWise.Models.ValueObjects;

namespace WalletWise.Models.Entities;

public partial class Expense
{
    public int ExpenId { get; set; }

    public string ExpenUserId { get; set; }
    public Money Amount { get; set; }

    // public decimal ExpenTotalAmount { get; set; }

    // public string ExpenCurrency { get; set; }

    public string ExpenName { get; set; }

    public DateTime ExpenDate { get; set; }

    public int? ExpenTag1 { get; set; }

    public int? ExpenTag2 { get; set; }

    public int? ExpenTag3 { get; set; }

    public int? ExpenTag4 { get; set; }

    public int? ExpenTag5 { get; set; }

    public string ExpenLocation { get; set; }
    public DateTime ExpenModTimestamp { get; set; }

    public virtual Tag ExpenTag1Navigation { get; set; }

    public virtual Tag ExpenTag2Navigation { get; set; }

    public virtual Tag ExpenTag3Navigation { get; set; }

    public virtual Tag ExpenTag4Navigation { get; set; }

    public virtual Tag ExpenTag5Navigation { get; set; }

    public virtual ICollection<ExpenseDetail> ExpenseDetails { get; set; } = new List<ExpenseDetail>();
}
