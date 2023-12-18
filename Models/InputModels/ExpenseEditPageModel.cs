using WalletWise.Models.ViewModels;

namespace WalletWise.Models.InputModels;

public class ExpenseEditPageModel
{
     public ExpenseEditModel ExpenseEditModel { get; set; }
     public List<CurrencyViewModel> CurrencyInputModel { get; set; }
}
