using CreditCardBL.CreditCardBL;
using CreditCardCore;
using System;
using System.Data.SqlClient;

namespace CreditCardBL
{
    public class CreditInputs : ICreditInputs
    {
        public void GetDataForDataTable()
        {
            throw new NotImplementedException();
        }

        public void InsertIntoTable(string ExpenseType, DateTime Date, int Amount, string Purpose, string Card, string Limit)
        {
            try
            {
                DBInteractionClass dBInteractionClass = new DBInteractionClass();
                dBInteractionClass.InsertValues(ExpenseType, Date, Amount, Purpose, Card, Limit);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
