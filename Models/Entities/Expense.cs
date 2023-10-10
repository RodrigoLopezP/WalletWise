using System;
using System.Collections.Generic;

namespace WalletWise.Models.Entities;

public partial class Expense
{
    public required int ExpenId { get; set; }

    public string ExpenUserId { get; set; }

    public required decimal ExpenTotalAmount { get; set; }

    public required string ExpenCurrency { get; set; }

    public string? ExpenName { get; set; }

    public required DateTime ExpenDate { get; set; }

    public int? ExpenTag1 { get; set; }

    public int? ExpenTag2 { get; set; }

    public int? ExpenTag3 { get; set; }

    public int? ExpenTag4 { get; set; }

    public int? ExpenTag5 { get; set; }

    public string ExpenLocation { get; set; }

    public virtual Tag Tag { get; set; }
}
