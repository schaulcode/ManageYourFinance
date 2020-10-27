using ManageYourFinance.App.Models;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageYourFinance.App.Controllers
{
    public class TransactionsController : Controller
    {
        readonly IDataServices<Data.Models.Transactions> db = new SqlDataServices<Data.Models.Transactions>();
        // GET: Transactions
        public ActionResult Index()
        {
            var data = db.GetAll();
            var model = new List<Transactions>();
            model = data.Select(e => new Transactions(e)).ToList();
            return View(model);
        }

        // GET: Transactions/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Get(id);
            var model = new Transactions(data);
            return View(model);
        }

        // GET: Transactions/Create
        public ActionResult Create()
        {
            ViewBag.Accounts = new SqlDataServices<Data.Models.Accounts>().GetAll().Select(e => new SelectListItem { Text = e.Name, Value = e.ID.ToString() });
            ViewBag.Category = new SqlDataServices<Data.Models.Category>().GetAll().Select(e => new SelectListItem { Text = e.Name, Value = e.ID.ToString() });
            ViewBag.Payee = new SqlDataServices<Data.Models.Payee>().GetAll().Select(e => new SelectListItem { Text = e.Name, Value = e.ID.ToString() });
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        public ActionResult Create(Transactions data, string accounts, string category, string payee)
        {
            try
            {
                // TODO: Add insert logic here
                data.AccountsID = int.Parse(accounts);
                data.CategoryID = int.Parse(category);
                data.PayeeID = int.Parse(payee);
                db.Add(data.Reversemapper());
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "An Error occured your entry hasn't been saved";
                return RedirectToAction("Index");
            }
        }

        // GET: Transactions/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Get(id);
            var model = new Transactions(data);

            var accounts = new SqlDataServices<Data.Models.Accounts>().GetAll().Select(e => new SelectListItem { Text = e.Name, Value = e.ID.ToString() });
            var category = new SqlDataServices<Data.Models.Category>().GetAll().Select(e => new SelectListItem { Text = e.Name, Value = e.ID.ToString() });
            var payee = new SqlDataServices<Data.Models.Payee>().GetAll().Select(e => new SelectListItem { Text = e.Name, Value = e.ID.ToString() });
            accounts.First(e => e.Value == data.AccountsID.ToString()).Selected = true;
            category.First(e => e.Value == data.CategoryID.ToString()).Selected = true;
            payee.First(e => e.Value == data.PayeeID.ToString()).Selected = true;
            ViewBag.Accounts = accounts;
            ViewBag.Category = category;
            ViewBag.Payee = payee;
            
            return View(model);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        public ActionResult Edit(Transactions data, string accounts, string category, string payee, int id)
        {
            try
            {
                // TODO: Add update logic here
                data.AccountsID = int.Parse(accounts);
                data.CategoryID = int.Parse(category);
                data.PayeeID = int.Parse(payee);
                db.Edit(id, data.Reversemapper());
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "An Error occoured yor entry coudn't be updated";
                return View();
            }
        }

        // GET: Transactions/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Get(id);
            var model = new Transactions(data);
            return View(model);
        }

        // POST: Transactions/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["errorMessage"] = "Sorry, we couldn't delete your entry";
                return RedirectToAction("Delete", id);
            }
        }
    }
}
