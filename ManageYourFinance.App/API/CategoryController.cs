using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ManageYourFinance.App.API
{
    public class CategoryController : ApiController
    {
        readonly IDataServices<Data.Models.Category> db = new SqlDataServices<Data.Models.Category>();
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            var data = db.Get(id);
            string result;
            if (data.Type == Data.Enums.CategoryType.Income)
            {
                result = "Income";
            }
            else
            {
                result = "Expense";
            }
            return result;
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}