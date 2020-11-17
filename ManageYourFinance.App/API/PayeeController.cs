using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManageYourFinance.App.API
{
    public class PayeeController : ApiController
    {
        readonly IDataServices<Data.Models.Payee> db = new SqlDataServices<Data.Models.Payee>();
        // GET api/<controller>/5
        public string Get(int id)
        {
            var data = db.Get(id);
            int result = data.CategoryID;
            
            return result.ToString();
        }
    }
}
