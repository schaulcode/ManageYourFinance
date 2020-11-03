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
            model = data.Select(e => new Transactions(e)).OrderBy(e => e.Date).ToList();
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
            ViewBag.Accounts = new SqlDataServices<Data.Models.Accounts>().GetAll();
            ViewBag.Category = new SqlDataServices<Data.Models.Category>().GetAll();
            ViewBag.Payee = new SqlDataServices<Data.Models.Payee>().GetAll();
            return View();
        }

        // POST: Transactions/Create
        [HttpPost]
        public ActionResult Create(Transactions data )
        {
            try
            {
                // TODO: Add insert logic here
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

            var accounts = new SqlDataServices<Data.Models.Accounts>().GetAll();
            var category = new SqlDataServices<Data.Models.Category>().GetAll();
            var payee = new SqlDataServices<Data.Models.Payee>().GetAll();
            ViewBag.AccountsSelected = accounts.First(e => e.ID == model.AccountsID);
            ViewBag.CategorySelected = category.First(e => e.ID == model.CategoryID);
            ViewBag.PayeeSelected = payee.First(e => e.ID == model.PayeeID);
            ViewBag.Accounts = accounts;
            ViewBag.Category = category;
            ViewBag.Payee = payee;
            
            return View(model);
        }

        // POST: Transactions/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Transactions data)
        {
            try
            {
                // TODO: Add update logic here
                db.Edit(id, data.Reversemapper());
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "An Error occoured yor entry coudn't be updated";
                return RedirectToAction("Edit", data.ID);
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
