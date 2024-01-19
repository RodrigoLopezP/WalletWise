using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletWise.Models.InputModels
{
    public class ExpenseInputModel
    {
        [Required(ErrorMessage = "Name field is required"),
        MaxLength(100, ErrorMessage = "Max lenght: 100 characters"),
        Display(Name = "Name")
        ]
        public required string Name { get; set; }

        [Required(ErrorMessage ="Amount field is required"),
        Display(Name="Total amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Currency field is required"),
        Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        [Required(ErrorMessage ="Date field is required"),
        Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }

        [Display(Name = "Note")]
        public string? Note { get; set; }
    }
}