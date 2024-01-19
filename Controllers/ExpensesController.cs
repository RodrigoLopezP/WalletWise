using Microsoft.AspNetCore.Mvc;
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
            if (ModelState.IsValid == false)
            {
                _logger.LogWarning("Add Expense - ModelState not valid");
                List<string> errorFields= new ();
                foreach (var item in ModelState)
                {
                    if(item.Value.Errors.Count!=1)
                        continue;
                    else if(item.Key.Contains(nameof(ExpenseListViewModel.NewExpense))==false)
                        continue;
                    else
                        errorFields.Add(item.Key);
                }
                string errorFieldMessage= string.Join(" | ",errorFields);
                TempData["WarningMessage"] = $"Add expense failed - check the fields and try again - {errorFieldMessage}";
                return RedirectToAction(nameof(Index));
            }
            await _expenseService.AddExpenseAsync(inputModel.NewExpense);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet(nameof(Edit))]
        public async Task<IActionResult> Edit(int Id)
        {
            bool expenseExist=await _expenseService.ExistExpenseById(Id);
            if (expenseExist is false){
                _logger.LogWarning($"Edit action can't proceed. Expense id {Id} not exists");
                return View();
            }
            _logger.LogDebug($"Edit action | Expense {Id} was found");
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
                ExpenseEditPageModel expenseEditPageModel=new(){
                    ExpenseEditModel=expenseEditModel,
                    CurrencyInputModel=await _currencyService.GetCurrenciesAsync()
                };
                ViewData["Title"]="Edit expense";
                return View(expenseEditPageModel);
            }
            try
            {
                bool expExist = await _expenseService.ExistExpenseById(expenseEditModel.Id);
                if (expExist == false)
                {
                    return View();
                }
                _logger.LogInformation(expenseEditModel.Id, $"Edit expense: id {expenseEditModel.Id} - id utente: {expenseEditModel.UserId}");
                ExpenseEditModel editedExpense= await _expenseService.EditExpensesAsync(expenseEditModel);
                return RedirectToAction(nameof(Index));
            }
            catch (SystemException exc)
            {
                _logger.LogError(expenseEditModel.Id, $"Something is wrong during - Edit expense: id {expenseEditModel.Id} - id utente: {expenseEditModel.UserId} - Exception {exc.Message}");
                throw;
            }
        }

        [HttpDelete(nameof(Delete))]
        public async Task<IActionResult> Delete(int id)
        {
            bool existId = await _expenseService.ExistExpenseById(id);
            if (!existId)
            {
                return View();
            }
            await _expenseService.DeleteExpense(id);
            return RedirectToAction(nameof(ExpensesController.Index),"Home");
        }
    }
}