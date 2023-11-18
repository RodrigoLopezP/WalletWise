using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.InputModels;

namespace WalletWise.Models.ViewModels
{
    public class ExpenseListViewModel
    {
        public List<ExpenseViewModel> ExpenseList { get; set; }
        public ExpenseInputModel NewExpense { get; set; }
        public List<CurrencyViewModel> CurrencyList { get; set; }
    }
}