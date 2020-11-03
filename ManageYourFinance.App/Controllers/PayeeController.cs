using ManageYourFinance.App.Models;
using ManageYourFinance.Data.Models;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Payee = ManageYourFinance.App.Models.Payee;
using Transactions = ManageYourFinance.App.Models.Transactions;

namespace ManageYourFinance.App.Controllers
{
    public class PayeeController : Controller
    {
        readonly IDataServices<Data.Models.Payee> db = new SqlDataServices<Data.Models.Payee>();
        // GET: Payee
        public ActionResult Index()
        {
            var data = db.GetAll().OrderBy(e => e.Name);
            var model = new List<Payee>();
            foreach (var item in data)
            {
                model.Add(new Payee(item));
            }
            return View(model.OrderBy(e => e.Name));
        }

        // GET: Payee/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Get(id);
            var model = new Payee(data);
            var transactionsData = new SqlDataServices<Data.Models.Transactions>().GetAll(id, typeof(Data.Models.Category)).OrderBy(e => e.Date);
            foreach (var item in transactionsData)
            {
                model.Transactions.Add(new Transactions(item));
            }
            return View(model);
        }

        // GET: Payee/Create
        public ActionResult Create()
        {
            var categorylist = new SqlDataServices<Data.Models.Category>().GetAll().OrderBy(e => e.Name);
            ViewBag.Category = categorylist;
            return View();
        }

        // POST: Payee/Create
        [HttpPost]
        public ActionResult Create(Payee data)
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

        // GET: Payee/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Get(id);
            var model = new Payee(data);
            var categorylist = new SqlDataServices<Data.Models.Category>().GetAll().OrderBy(e => e.Name);
            List<SelectListItem> selectList = new List<SelectListItem>();
            foreach (var item in categorylist)
            {
                selectList.Add(new SelectListItem { Text = item.Name, Value = item.ID.ToString() });
            }
            selectList.Find(e => e.Value == model.CategoryID.ToString()).Selected = true;
            ViewBag.Category = categorylist;
            ViewBag.Selected = categorylist.First(e => e.ID == model.CategoryID);
            return View(model);
        }

        // POST: Payee/Edit/5
        [HttpPost]
        public ActionResult Edit(Payee data)
        {
            try
            {
                // TODO: Add update logic here
                db.Edit(data.ID, data.ReverseMapper());
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "An Error occoured yor entry coudn't be updated";
                return RedirectToAction("Edit", data.ID);
            }
        }

        // GET: Payee/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Get(id);
            var model = new Payee(data);
            return View(model);
        }

        // POST: Payee/Delete/5
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
