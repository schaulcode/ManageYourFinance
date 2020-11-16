using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManageYourFinance.App.Models
{
    public class Payee
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int CategoryID { get; set; } = 0;
        public string Category { get; set; }
        public List<Transactions> Transactions { get; set; } = new List<Transactions>();
        public double Total { get; set; }
        public Payee()
        {

        }
        public Payee(Data.Models.Payee data)
        {
            this.ID = data.ID;
            this.Name = data.Name;
            this.Active = data.Active;
            this.CategoryID = data.CategoryID;
            this.Category = new SqlDataServices<Data.Models.Category>().Get(CategoryID)?.Name;
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