using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletWise.Models.Entities;

namespace WalletWise.Models.ViewModels
{
    public class CurrencyViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Acronym { get; set; }

        public static CurrencyViewModel FromEntity(Currency entity)
        {
            return new CurrencyViewModel()
            {
                Id = entity.CurrId,
                FullName = entity.CurrName,
                Acronym = entity.CurrAcronym
            };
        }
    }
}