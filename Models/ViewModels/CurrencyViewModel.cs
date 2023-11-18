using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletWise.Models.ViewModels
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Acronym { get; set; }
    }
}