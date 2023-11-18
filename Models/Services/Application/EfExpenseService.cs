using System;
using System.Collections.Generic;
using System.Linq;
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
               // string tempCurrency=Currency.EUR.ToString();
               string tempCurrency="EUR";
               Expense newExpense = new()
               {
                    ExpenName = inputModel.Name,
                    // ExpenAmount = new(tempCurrency,
                    //                inputModel.Amount),
                    ExpenDate = inputModel.Date,
                    ExpenLocation = inputModel.Location,
                    ExpenModTimestamp = DateAndTime.Now,
                    ExpenUserId = tempUsername,
               };
               dbContextWW.Add(newExpense);
               await dbContextWW.SaveChangesAsync();
               return;
          }

          public async Task<List<ExpenseViewModel>> GetExpensesAsync(string userId)
          {
               IQueryable<Expense> queryLinQ = dbContextWW.Expenses;
               List<ExpenseViewModel> a = await queryLinQ
                              .AsNoTracking()
                              .Where(exp => exp.ExpenUserId == userId)
                              .Include(c=> c.ExpenCurrencyNavigation)
                              .OrderByDescending(x => x.ExpenDate)
                              .Select(x =>ExpenseViewModel.FromEntity(x))
                              .ToListAsync();
               return a;
          }
     }
}