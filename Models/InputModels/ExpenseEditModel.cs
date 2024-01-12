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

        [Required(ErrorMessage ="Amount can't be null"),
        Display(Name="Total amount")]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Name field is obbligatory"),
        MaxLength(100, ErrorMessage = "Lunghezza massima del nome: 100 caratteri"),
        Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Date field is required"),
        Display(Name = "Date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Location")]
        public string? Location { get; set; }
        [Display(Name="Note")]
        public string? Note { get; set; }
        
        [Display(Name ="Currency")]
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
                Note=ent.ExpenNote,
                CurrencyId=ent.ExpenCurrencyId
            };
            return result;
        }
    }
}