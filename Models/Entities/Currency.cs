using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletWise.Models.Entities
{
    public class Currency
    {
        [Key]
        public int CurrId { get; set; }
        public string CurrName { get; set; }
        public string CurrAcronym { get; set; }
        public virtual ICollection<Expense> CurrencyExpenseNavigations { get; set; } = new List<Expense>();
        public virtual ICollection<ExpenseDetail> CurrencyExpensedetailNavigations { get; set; } = new List<ExpenseDetail>();
    }
}