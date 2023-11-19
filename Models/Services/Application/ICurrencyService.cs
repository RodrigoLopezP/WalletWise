using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.Entities;
using WalletWise.Models.InputModels;
using WalletWise.Models.ViewModels;

namespace WalletWise.Models.Services.Application
{
    public interface ICurrencyService
    {
        Task AddCurrencyAsync(CurrencyInputModel inputModel);
        Task <List<CurrencyViewModel>> GetExpensesAsync();
    }
}