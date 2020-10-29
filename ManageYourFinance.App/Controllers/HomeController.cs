using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageYourFinance.App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AccountsCount = new SqlDataServices<Data.Models.Accounts>().GetAll().Count;
            ViewBag.CategoryCount = new SqlDataServices<Data.Models.Category>().GetAll().Count;
            ViewBag.PayeeCount = new SqlDataServices<Data.Models.Payee>().GetAll().Count;
            ViewBag.ScheduleCount = new SqlDataServices<Data.Models.Schedule>().GetAll().Count;
            ViewBag.TransactionsCount = new SqlDataServices<Data.Models.Transactions>().GetAll().Count;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}