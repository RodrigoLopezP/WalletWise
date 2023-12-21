using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.InputModels;
using WalletWise.Models.ViewModels;

namespace WalletWise.Models.Services.Application
{
    public interface IExpenseService
    {
        Task AddExpenseAsync(ExpenseInputModel inputModel);
        Task<ExpenseEditModel> GetExpenseForEdit(int id);
        Task <List<ExpenseViewModel>> GetExpensesAsync(string userId);
        Task<ExpenseEditModel> EditExpensesAsync(ExpenseEditModel expenseToEdit);
        Task<bool> ExistExpenseById(int id);
        Task DeleteExpense(int expenId);
    }
}