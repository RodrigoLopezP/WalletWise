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
        Display(Name = "Nome")
        ]
        public required string Name { get; set; }

        [Required(ErrorMessage = "La quantità spesa è richiesta"),
        Display(Name = "Quantità")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "La valuta è richiesta"),
        Display(Name = "Valuta")]
        public int CurrencyId { get; set; }//ToDo: levare il nullable

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Luogo")]
        public string? Location { get; set; }
    }
}