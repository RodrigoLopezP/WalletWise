using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WalletWise.Models.InputModels;
using WalletWise.Models.Services.Application;
using WalletWise.Models.ViewModels;

namespace WalletWise.Controllers
{
    [Route("[controller]")]
    public class ExpensesController(ILogger<ExpensesController> _logger,
                                    IExpenseService _expenseService,
                                    ICurrencyService _currencyService)
                                    : Controller
    {

        public async Task<IActionResult> Index()
        {
            string userId = "anon";
            _logger.LogTrace($"Select all expenses - userId {userId}");
            ExpenseListViewModel viewModel = new()
            {
                ExpenseList = await _expenseService.GetExpensesAsync(userId)
            };
            _logger.LogTrace($"Select all currencies for insert modal- userId {userId}");
            viewModel.CurrencyList = await _currencyService.GetExpensesAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseListViewModel inputModel)
        {
            await _expenseService.AddExpenseAsync(inputModel.NewExpense);
            return RedirectToAction(nameof(Index));
        }
    }
}