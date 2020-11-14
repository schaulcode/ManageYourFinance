using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ManageYourFinance.App.Models;
using ManageYourFinance.Data.Services;
using Microsoft.Ajax.Utilities;

namespace ManageYourFinance.App.Controllers
{
    public class AccountsController : Controller
    {
        readonly IDataServices<Data.Models.Accounts> db = new SqlDataServices<Data.Models.Accounts>();
        // GET: Accounts
        public ActionResult Index()
        {
            var data = db.GetAll().OrderBy(e => e.Name);
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
            var transactionsData = new SqlDataServices<Data.Models.Transactions>().GetAll(id, typeof(Accounts)).OrderBy(e => e.Date);
            foreach (var item in transactionsData)
            {
                model.Transactions.Add(new Transactions(item));
            }
            return View(model);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,Type,Active,IncludeTotal,OpeningBalance")] Accounts data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
   
            
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
            return View(model);
        }

        // POST: Accounts/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,Type,Active,IncludeTotal,OpeningBalance")] Accounts data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
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
        public ActionResult Delete(int id, string confirmation = "")
        {
            try
            {
                // TODO: Add delete logic here
                if (confirmation == "false")
                {
                    var transactionDb = new SqlDataServices<Data.Models.Transactions>();
                    transactionDb.Delete(id, typeof(Accounts));
                }
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch(SqlException e)
            {
                if (e.Number == 547)
                {
                    TempData["errorMessage"] = "If you Delete this entry you will delete all associated Transactions Do you want to procced?";
                    TempData["deleteError"] = true;
                    return RedirectToAction("Delete", id);
                }
                TempData["errorMessage"] = "Sorry the requested command couldn't be performed please try again later ";
                return RedirectToAction("Delete", id);
            }
            catch
            {
                TempData["errorMessage"] = "Sorry, we couldn't delete your entry";
                return RedirectToAction("Delete",id);
            }
        }
    }
}
