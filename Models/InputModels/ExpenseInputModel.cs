using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WalletWise.Models.InputModels
{
    public class ExpenseInputModel
    {
        [Required(ErrorMessage = "Il nome è obbligatorio"),
        MaxLength(100, ErrorMessage = "Lunghezza massima del nome: 100 caratteri"),
        Display(Name = "Name")
        ]
        public required string Name { get; set; }

        [Required(ErrorMessage ="This field can't be null"),
        Display(Name="Total amount")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "La valuta è richiesta"),
        Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        [Display(Name = "Date")]
        public DateTime Date { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }

        [Display(Name = "Note")]
        public string? Note { get; set; }
    }
}