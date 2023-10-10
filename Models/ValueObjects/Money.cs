using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletWise.Models.ValueObjects
{
     public class Money
     {
          public Money() : this("???", 0.00m)
          {
          }
          public Money(string currency, decimal amount)
          {
               Amount = amount;
               Currency = currency;
          }
          private decimal amount = 0;
          public string Currency
          {
               get; init;
          }
          public decimal Amount
          {
               get
               {
                    return amount;
               }
               set
               {
                    if (value < 0)
                    {
                         throw new InvalidOperationException("The amount cannot be negative");
                    }
                    amount = value;
               }
          }

          public override string ToString()
          {
               return $"{Amount:#.00} {Currency}";
          }
     }
}