using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CreditCardBL.CreditCardBL
{
    public interface ICreditInputs
    {
        public void InsertIntoTable(string ExpenseType, DateTime Date, int Amount, string Purpose, string Card, string Limit);
        public ArrayList GetDataForDataTable();
        public string GetLastAvailableLimit();
        public ArrayList GetAllData();

    }
}
