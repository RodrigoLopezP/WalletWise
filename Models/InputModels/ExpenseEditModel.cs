using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.Entities;

namespace WalletWise.Models.InputModels
{
    public class ExpenseEditModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        [Required(ErrorMessage ="This field can't be null"),
        Display(Name="Total amount")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio"),
        MaxLength(100, ErrorMessage = "Lunghezza massima del nome: 100 caratteri"),
        Display(Name = "Nome")]
        public string Name { get; set; }

        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Display(Name = "Luogo")]
        public string Location { get; set; }

        public int CurrencyId {get; set;}
        public static ExpenseEditModel FromEntity(Expense ent)
        {
            ExpenseEditModel result = new(){
                Id=ent.ExpenId,
                UserId=ent.ExpenUserId,
                TotalAmount=ent.ExpenTotalAmount,
                Name= ent.ExpenName,
                Date=ent.ExpenDate,
                Location=ent.ExpenLocation,
                CurrencyId=ent.ExpenCurrencyId
            };
            return result;
        }
    }
}