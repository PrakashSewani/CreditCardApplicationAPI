using CreditCardAPI.Models;
using CreditCardBL;
using CreditCardBL.CreditCardBL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class HomeController : ControllerBase
    {
        [HttpPost("AddValues")]
        public ActionResult AddValues(Inputs inputs)
        {
            ActionResult returnResult = new NoContentResult();
            try
            {
                string ExpenseType = inputs.ExpenseType;
                DateTime Date = inputs.Date;
                int Amount = inputs.Amount;
                string Purpose = inputs.ExpensePurpose;
                string Card = inputs.Card;
                string Limit = inputs.AvailableLimit;

                ICreditInputs creditInputs = new CreditInputs();
                creditInputs.InsertIntoTable(ExpenseType, Date, Amount, Purpose, Card, Limit);
                return returnResult;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpGet("FetchValues")]
        public ArrayList FetchValues()
        {
            //ActionResult returnResult = new NoContentResult();
            ArrayList expenseTable = new ArrayList();
            try
            {
                ICreditInputs fetchData = new CreditInputs();
                expenseTable=fetchData.GetDataForDataTable();
                return expenseTable;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("FetchLastLimit")]
        public string FetchLastLimit()
        {
            string limits = null;
            try
            {
                ICreditInputs fetchLastLimit = new CreditInputs();
                limits = fetchLastLimit.GetLastAvailableLimit();
                return limits;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
