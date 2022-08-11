using System;
using System.Data;
using System.Data.SqlClient;

namespace CreditCardCore
{
    public class DBInteractionClass
    {
        public void InsertValues(string ExpenseType, DateTime Date, int Amount, string Purpose, string Card, string Limit)
        {
            SqlConnection con = null;
            string query = "INSERT INTO ExpenseTable(ExpenseType,ExpenseDate,ExpenseAmount,Card,AvailableLimit,ExpensePurpose)" + "VALUES(@ExpenseType,@ExpenseDate,@ExpenseAmount,@Card,@AvailableLimit,@ExpensePurpose)";
            try
            {
                con = new SqlConnection("data source=DESKTOP-S7GOFP1\\SQLEXPRESS;database=CreditCardExpense; integrated security=SSPI");

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.Add("@ExpenseType", SqlDbType.VarChar, 50).Value = ExpenseType;
                cmd.Parameters.Add("@ExpenseDate", SqlDbType.DateTime, 20).Value = Date;
                cmd.Parameters.Add("@ExpenseAmount", SqlDbType.Int, 20).Value = Amount;
                cmd.Parameters.Add("@Card", SqlDbType.VarChar, 50).Value = Card;
                cmd.Parameters.Add("@AvailableLimit", SqlDbType.VarChar, 50).Value = Limit;
                cmd.Parameters.Add("@ExpensePurpose", SqlDbType.VarChar, 50).Value = Purpose;

                con.Open();

                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                con.Close();
            }
        }
       
    }
}
