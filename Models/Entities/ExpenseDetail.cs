using System;
using System.Collections.Generic;
using WalletWise.Models.ValueObjects;

namespace WalletWise.Models.Entities;

public partial class ExpenseDetail
{
    public int ExdetId { get; set; }

    public int ExdetExpenId { get; set; }

    public string ExdetName { get; set; }

    //  public Money Amount { get; set; }
    public decimal ExdetAmount { get; set; }

    public string ExdetCurrency { get; set; }

    public virtual Expense ExdetExpen { get; set; }
    public DateTime ExdetModTimestamp { get; set; }
}
