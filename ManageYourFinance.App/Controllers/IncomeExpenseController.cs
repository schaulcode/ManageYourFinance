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
            return View();
        }
    }
}