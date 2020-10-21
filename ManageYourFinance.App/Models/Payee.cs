using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class Payee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public int CategoryID { get; set; }
        public List<Transactions> Transactions { get; set; }
        public Payee()
        {

        }
        public Payee(Data.Models.Payee data)
        {
            this.ID = data.ID;
            this.Name = data.Name;
            this.Active = data.Active;
            this.CategoryID = data.CategoryID;
        }
        public Data.Models.Payee ReverseMapper()
        {
            return new Data.Models.Payee
            {
                ID = this.ID,
                Name = this.Name,
                Active = this.Active,
                CategoryID = this.CategoryID
            };
        }

    }
}