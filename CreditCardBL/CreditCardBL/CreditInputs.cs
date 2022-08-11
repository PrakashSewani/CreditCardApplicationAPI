using CreditCardBL.CreditCardBL;
using CreditCardCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CreditCardBL
{
    public class CreditInputs : ICreditInputs
    {
        public string GetLastAvailableLimit()
        {
            string LastAvailableLimit;
            try
            {
                DBInteractionClass dBInteractionClass = new DBInteractionClass();
                LastAvailableLimit = dBInteractionClass.GetLastLimit();
            }
            catch (Exception)
            {

                throw;
            }
            return LastAvailableLimit;
        }

        public ArrayList GetDataForDataTable()
        {
            ArrayList expenseTable = new ArrayList();
            try
            {
                DBInteractionClass dBInteractionClass = new DBInteractionClass();
                expenseTable=dBInteractionClass.GetValues();
            }
            catch (Exception)
            {

                throw;
            }
            return expenseTable;
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
