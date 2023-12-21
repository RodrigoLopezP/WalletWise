using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.Entities;
using WalletWise.Models.ValueObjects;

namespace WalletWise.Models.ViewModels
{
    public class ExpenseViewModel
    {
        public int Id { get; set; }
        public required string IdUser { get; set; }
        public DateTime Date { get; set; } 
        public decimal Amount { get; set; }
        public string Currency { get; set; }     
        public string Name { get; set; }
        public string? Location { get; set; }
        public string? Note { get; set; }
        
        
        // public List<TagsViewModel> Tags { get; set; }
        public static ExpenseViewModel FromEntity(Expense entity)
        {
            return new ExpenseViewModel()
            {
                Id = entity.ExpenId,
                IdUser = entity.ExpenUserId,
                Date = entity.ExpenDate,
                Amount = entity.ExpenTotalAmount,
                Currency = entity.ExpenCurrencyNavigation.CurrAcronym,
                Name = entity.ExpenName,
                Location = entity.ExpenLocation,
                Note = entity.ExpenNote
            };
        }
    }
}