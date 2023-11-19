using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WalletWise.Models.InputModels;
using WalletWise.Models.Services.Infrastructure;
using WalletWise.Models.ViewModels;

namespace WalletWise.Models.Services.Application
{
    public class EfCurrencyService : ICurrencyService
    {
        private readonly DbContextWalletWise _dbContextWW;

        public EfCurrencyService(DbContextWalletWise dbContextWalletWise)
        {
            this._dbContextWW = dbContextWalletWise;
        }
        public Task AddCurrencyAsync(CurrencyInputModel inputModel)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CurrencyViewModel>> GetExpensesAsync()
        {
            var query =  _dbContextWW.Currencies
                    .AsNoTracking()
                    .Select(ent => CurrencyViewModel.FromEntity(ent));

            List<CurrencyViewModel> result = await query.ToListAsync();
            return result;
        }
    }
}