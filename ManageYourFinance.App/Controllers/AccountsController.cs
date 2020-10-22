using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageYourFinance.App.Models;
using ManageYourFinance.Data.Services;

namespace ManageYourFinance.App.Controllers
{
    public class AccountsController : Controller
    {
        readonly IDataServices<Data.Models.Accounts> db = new SqlDataServices<Data.Models.Accounts>();
        // GET: Accounts
        public ActionResult Index()
        {
            var data = db.GetAll();
            var model = new List<Accounts>();
            foreach (var item in data)
            {
                model.Add(new Accounts(item));
            }
            return View(model);
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Get(id);
            var model = new Accounts(data);
            var transactionsData = new SqlDataServices<Data.Models.Transactions>().GetAll(id, typeof(Accounts));
            foreach (var item in transactionsData)
            {
                model.Transactions.Add(new Transactions(item));
            }
            return View(model);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            List<SelectListItem> selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Credit Card", Value = "Credit Card" },
                new SelectListItem { Text = "Cash", Value ="Cash"},
                new SelectListItem { Text = "Bank Account", Value = "Bank Account"},
                new SelectListItem { Text = "Other Account", Value = "Other Account"}
            };
            ViewBag.AccountType = selectList;
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Type,Active,IncludeTotal,OpeningBalance")] Accounts data)
        {
            try
            {
                // TODO: Add insert logic here
                db.Add(data.ReverseMapper());
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "An Error occured your entry hasn't been saved";
                return RedirectToAction("Index");
            }
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Get(id);
            var model = new Accounts(data);
            List<SelectListItem> selectList = new List<SelectListItem>()
            {
                new SelectListItem { Text = "Credit Card", Value = "Credit Card" },
                new SelectListItem { Text = "Cash", Value ="Cash"},
                new SelectListItem { Text = "Bank Account", Value = "Bank Account"},
                new SelectListItem { Text = "Other Account", Value = "Other Account"}
            };
            selectList.Find(e => e.Value == model.Type).Selected = true;
            ViewBag.AccountType = selectList;
            return View(model);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,Active,IncludeTotal,OpeningBalance")] Accounts data)
        {
            try
            {
                // TODO: Add update logic here
                int id = data.ID;
                db.Edit(id,data.ReverseMapper());

                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "An Error occoured yor entry coudn't be updated";
                return View();
            }
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Get(id);
            var model = new Accounts(data);
            return View(model);
        }

        // POST: Accounts/Delete/5
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
                return RedirectToAction("Delete",id);
            }
        }
    }
}
