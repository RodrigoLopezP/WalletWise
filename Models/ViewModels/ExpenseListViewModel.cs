using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.ValueObjects;

namespace WalletWise.Models.ViewModels
{
    public class ExpenseListViewModel
    {
        public int Id { get; set; }
        public required string IdUser { get; set; }
        public DateOnly Date { get; set; } 
        public decimal Amount  { get; set; }
        public string? Name { get; set; }
        public string Location { get; set; }
        // public List<TagsViewModel> Tags { get; set; }
    }
}