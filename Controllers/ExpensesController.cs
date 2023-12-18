using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
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
            viewModel.CurrencyList = await _currencyService.GetCurrenciesAsync();
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ExpenseListViewModel inputModel)
        {
            await _expenseService.AddExpenseAsync(inputModel.NewExpense);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet(nameof(Edit))]
        public async Task<IActionResult> Edit(int Id)
        {
            ExpenseEditPageModel result= new();
            
            result.ExpenseEditModel= await _expenseService.GetExpenseForEdit(Id);
            result.CurrencyInputModel= await _currencyService.GetCurrenciesAsync();

            ViewData["Title"]="Edit expense";
            return View(result);
        }
        [HttpPost(nameof(Edit))]
        public async Task<IActionResult> Edit(ExpenseEditModel expenseEditModel)
        {
            if (ModelState.IsValid == false)
            {
                ViewBag["Title"] = "Edit expense";
                return View();
            }
            try
            {
                _logger.LogInformation(expenseEditModel.Id, $"Edit expense: id {expenseEditModel.Id} - id utente: {expenseEditModel.UserId}");
                ExpenseEditModel editedExpense= await _expenseService.EditExpensesAsync(expenseEditModel);
                return RedirectToAction(nameof(Index));
            }
            catch (SystemException exc)
            {
                _logger.LogError(expenseEditModel.Id, $"Something is wrong during - Edit expense: id {expenseEditModel.Id} - id utente: {expenseEditModel.UserId}");
                throw exc;
            }
        }
    }
}