using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalletWise.Models.ValueObjects;

namespace WalletWise.Models.Entities;

public partial class ExpenseDetail
{
    [Key]
    public int ExdetId { get; set; }

    public int ExdetExpenId { get; set; }
    public string ExdetName { get; set; }
    public decimal ExdetAmount { get; set; }
    public int ExdetCurrencyId{ get; set; }
    public DateTime ExdetModTimestamp { get; set; }
    public virtual Expense ExdetExpen { get; set; }
    public virtual Currency ExdetCurrencyNavigation { get; set; }
}
