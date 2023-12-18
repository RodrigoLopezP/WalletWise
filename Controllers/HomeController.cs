using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WalletWise.Models;

namespace WalletWise.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    private ILogger<HomeController> _logger => logger;

    public IActionResult Index()
    {
        string actionName=nameof(ExpensesController.Index);
        return RedirectToAction(actionName, "Expenses");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
