using ManageYourFinance.App.Models;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageYourFinance.App.Controllers
{
    public class IncomeExpenseController : Controller
    {
        
        // GET: IncomeExpense
        public ActionResult Index()
        {
            var model = new IncomeExpenseModel(Data.Enums.IncomeExpenseTimeSelector.ThisYear, Data.Enums.IncomeExpenseTimeSelector.LastYear);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(IncomeExpenseModel data)
        {
            data.UpdateModel();
            var model = data;
            return View(model);
        }
    }
}