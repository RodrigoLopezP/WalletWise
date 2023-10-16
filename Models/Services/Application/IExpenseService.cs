using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.ViewModels;

namespace WalletWise.Models.Services.Application
{
    public interface IExpenseService
    {
        Task <List<ExpenseViewModel>> GetExpensesAsync(string userId);
    }
}