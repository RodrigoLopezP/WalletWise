using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WalletWise.Models.Entities;
// using WalletWise.Models.Enums;
using WalletWise.Models.InputModels;
using WalletWise.Models.Services.Infrastructure;
using WalletWise.Models.ViewModels;

namespace WalletWise.Models.Services.Application
{
     public class EfExpenseService : IExpenseService
     {
          private readonly DbContextWalletWise dbContextWW;

          public EfExpenseService(DbContextWalletWise dbContextWW)
          {
               this.dbContextWW = dbContextWW;
          }

          public async Task AddExpenseAsync(ExpenseInputModel inputModel)
          {
               string tempUsername = "anon";
               Expense newExpense = new()
               {
                    ExpenUserId = tempUsername,
                    ExpenName = inputModel.Name,
                    ExpenTotalAmount=inputModel.Amount,
                    ExpenCurrencyId=inputModel.CurrencyId,
                    ExpenDate = inputModel.Date,
                    ExpenLocation = inputModel.Location,
                    ExpenModTimestamp = DateAndTime.Now,
               };
               dbContextWW.Add(newExpense);
               await dbContextWW.SaveChangesAsync();
               return;
          }

     public async Task<bool> ExistExpenseById(int id){
          bool result=await dbContextWW.Expenses
                    .Where(exp=> exp.ExpenId==id)
                    .AnyAsync();
          return result;
     }
        public async Task<ExpenseEditModel> GetExpenseForEdit(int id)
        {
            IQueryable<ExpenseEditModel> query= dbContextWW.Expenses
                              .Where(exp=> exp.ExpenId==id)
                              .AsNoTracking()
                              .Include(curr=> curr.ExpenCurrencyNavigation)
                              .Select( sel=> ExpenseEditModel.FromEntity(sel));

            ExpenseEditModel result= await query.SingleAsync();
            return result;
        }

        public async Task<List<ExpenseViewModel>> GetExpensesAsync(string userId)
          {
               IQueryable<Expense> queryLinQ = dbContextWW.Expenses;

               queryLinQ = queryLinQ
                              .AsNoTracking()
                              .Where(exp => exp.ExpenUserId == userId)
                              .Include(c => c.ExpenCurrencyNavigation)
                              .OrderByDescending(x => x.ExpenDate);

               List<ExpenseViewModel> a = await queryLinQ
                              .Select(x => ExpenseViewModel.FromEntity(x))
                              .ToListAsync();
               return a;
          }

          public async Task<ExpenseEditModel> EditExpensesAsync(ExpenseEditModel expenseEditModel)
          {
               Expense expenseToEdit= await dbContextWW.Expenses.FindAsync(expenseEditModel.Id);

               // expToEdit.ExpenId = expenseEditModel.Id;
               // expToEdit.ExpenUserId = expenseEditModel.UserId;
               expenseToEdit.ExpenTotalAmount = expenseEditModel.TotalAmount;
               expenseToEdit.ExpenCurrencyId = expenseEditModel.CurrencyId;
               expenseToEdit.ExpenName = expenseEditModel.Name;
               expenseToEdit.ExpenDate = expenseEditModel.Date;
               expenseToEdit.ExpenLocation = expenseEditModel.Location;
               expenseToEdit.ExpenModTimestamp = DateTime.Now;
               expenseToEdit.ExpenNote=expenseEditModel.Note;

               await dbContextWW.SaveChangesAsync();

               return ExpenseEditModel.FromEntity(expenseToEdit);
          }

        public async Task DeleteExpense(int expenId)
        {
          try
          {
          Expense expenseToDelete= await dbContextWW.Expenses
                                   .Where(exp=> exp.ExpenId==expenId)
                                   .AsNoTracking()
                                   .SingleAsync();
          dbContextWW.Remove(expenseToDelete);
          await dbContextWW.SaveChangesAsync();
          }
          catch (InvalidOperationException exc)
          {
               throw;
          }
          
        }
    }
}