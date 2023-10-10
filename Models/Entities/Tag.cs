using System;
using System.Collections.Generic;

namespace WalletWise.Models.Entities;

public partial class Tag
{
    public int TagId { get; set; }

    public string TagUserId { get; set; }

    public string TagName { get; set; }

    public string TagDescription { get; set; }

    public bool? TagIsPublic { get; set; }

    public virtual ICollection<Expense> ExpenseExpenTag1Navigations { get; set; } = new List<Expense>();

    public virtual ICollection<Expense> ExpenseExpenTag2Navigations { get; set; } = new List<Expense>();

    public virtual ICollection<Expense> ExpenseExpenTag3Navigations { get; set; } = new List<Expense>();

    public virtual ICollection<Expense> ExpenseExpenTag4Navigations { get; set; } = new List<Expense>();

    public virtual ICollection<Expense> ExpenseExpenTag5Navigations { get; set; } = new List<Expense>();
}
