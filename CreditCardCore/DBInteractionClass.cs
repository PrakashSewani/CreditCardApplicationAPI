using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace CreditCardCore
{
    public class DBInteractionClass
    {
        public void InsertValues(string ExpenseType, DateTime Date, int Amount, string Purpose, string Card, string Limit)
        {
            SqlConnection con = null;
            string query = "INSERT INTO ExpenseTable(ExpenseType,Date,Amount,Purpose,Card,Limit)" + "VALUES(@ExpenseType,@ExpenseDate,@ExpenseAmount,@ExpensePurpose,@Card,@AvailableLimit)";
            try
            {
                con = new SqlConnection("data source=DESKTOP-MSPVFKM\\SQLEXPRESS;database=CreditCardExpense; integrated security=SSPI");
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@ExpenseType", SqlDbType.VarChar, 225).Value = ExpenseType;
                cmd.Parameters.Add("@ExpenseDate", SqlDbType.DateTime, 20).Value = Date;
                cmd.Parameters.Add("@ExpenseAmount", SqlDbType.Int, 20).Value = Amount;
                cmd.Parameters.Add("@Card", SqlDbType.VarChar, 50).Value = Card;
                cmd.Parameters.Add("@AvailableLimit", SqlDbType.VarChar, 225).Value = Limit;
                cmd.Parameters.Add("@ExpensePurpose", SqlDbType.VarChar, 225).Value = Purpose;
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

        public ArrayList GetValues()
        {
            SqlConnection con = null;
            ArrayList expenseTable = new ArrayList();
            string query = "SELECT * FROM ExpenseTable";
            try
            {
                con = new SqlConnection("data source=DESKTOP-MSPVFKM\\SQLEXPRESS;database=CreditCardExpense; integrated security=SSPI");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string[] fields = new string[dataReader.FieldCount];
                    for (int i = 0; i < dataReader.FieldCount; ++i)
                        fields[i] = dataReader[i].ToString();
                    expenseTable.Add(fields);
                }
                dataReader.Close();
                return expenseTable;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            finally
            {
                con.Close();
            }
            return null;
        }

        public string GetLastLimit()
        {
            SqlConnection con = null;
            ArrayList expenseTable = new ArrayList();
            string LastLimit=null;
            string query = "SELECT TOP 1* FROM ExpenseTable ORDER BY id DESC;";
            try
            {
                con = new SqlConnection("data source=DESKTOP-MSPVFKM\\SQLEXPRESS;database=CreditCardExpense; integrated security=SSPI");
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    LastLimit = dataReader["Limit"].ToString();
                }
                dataReader.Close();
                
                return LastLimit;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
            return null;
        }
       
    }
}
