using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using WalletWise.Models.Entities;
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
          public async Task<List<ExpenseViewModel>> GetExpensesAsync(string userId)
          {
               IQueryable<Expense> queryLinQ = dbContextWW.Expenses;
               List<ExpenseViewModel> a = await queryLinQ.AsNoTracking()
                               .Where(exp => exp.ExpenUserId == userId)
                               .Select(x => new ExpenseViewModel
                               {
                                    Id = x.ExpenId,
                                    IdUser = x.ExpenUserId,
                                    Date = DateOnly.FromDateTime(x.ExpenDate),
                                    Amount = x.Amount,
                                    Name=x.ExpenName,
                                    Location=x.ExpenLocation                                    
                               })
                               .ToListAsync();

               return a;
          }
     }
}