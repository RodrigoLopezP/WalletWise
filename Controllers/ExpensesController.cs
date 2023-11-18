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
    public class ExpensesController : Controller
    {
        private readonly ILogger<ExpensesController> _logger;
          private readonly IExpenseService _expenseService;

          public ExpensesController(ILogger<ExpensesController> logger,
                                             IExpenseService expenseService)
        {
            _logger = logger;
               this._expenseService = expenseService;
          }

        public async Task<IActionResult> Index()
        {
            string userId="anon";
            // _logger.LogDebug("Getting expenses list  of {userId}...",userId);
            ExpenseListViewModel viewModel= new (){
                ExpenseList=await _expenseService.GetExpensesAsync(userId)
            };
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