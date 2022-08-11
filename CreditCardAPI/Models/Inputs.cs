using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardAPI.Models
{
    public class Inputs
    {
        public string ExpenseType { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string ExpensePurpose { get; set; }
        public string Card { get; set; }
        public string AvailableLimit { get; set; }
    }
}