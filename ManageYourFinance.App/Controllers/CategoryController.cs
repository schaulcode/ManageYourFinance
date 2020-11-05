using ManageYourFinance.App.Models;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManageYourFinance.App.Controllers
{
    public class CategoryController : Controller
    {
        readonly IDataServices<Data.Models.Category> db = new SqlDataServices<Data.Models.Category>();
        // GET: Category
        public ActionResult Index()
        {
            var data = db.GetAll().OrderBy(e => e.Name);
            var model = new List<Category>();
            foreach (var item in data)
            {
                model.Add(new Category(item));
            }
            return View(model.OrderBy(e => e.Name));
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var data = db.Get(id);
            var model = new Category(data);
            var transactionsData = new SqlDataServices<Data.Models.Transactions>().GetAll(model.ID, typeof(Data.Models.Category)).OrderBy(e => e.Date);
            foreach (var item in transactionsData)
            {
                model.Transactions.Add(new Transactions(item));
            }
            var payeeData = new SqlDataServices<Data.Models.Payee>().GetAll(model.ID, typeof(Data.Models.Category));
            foreach (var item in payeeData)
            {
                model.Payees.Add(new Payee(item));
            }
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category data)
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

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Get(id);
            var model = new Category(data);
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(Category data)
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Get(id);
            var model = new Category(data);
            return View(model);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, string confirmation = "")
        {
            try
            {
                // TODO: Add delete logic here
                if (confirmation == "false")
                {
                    var transactionDb = new SqlDataServices<Data.Models.Transactions>();
                    var payeeDb = new SqlDataServices<Data.Models.Payee>();
                    transactionDb.Delete(id, typeof(Category));
                    payeeDb.Delete(id, typeof(Category));
                }
                db.Delete(id);
                return RedirectToAction("Index");
            }
            catch (SqlException e)
            {
                if (e.Number == 547)
                {
                    TempData["errorMessage"] = "If you Delete this entry you will delete all associated Transactions and Payees Do you want to procced?";
                    TempData["deleteError"] = true;
                    return RedirectToAction("Delete", id);
                }
                TempData["errorMessage"] = "Sorry the requested command couldn't be performed please try again later ";
                return RedirectToAction("Delete", id);
            }
            catch
            {
                TempData["errorMessage"] = "Sorry, we couldn't delete your entry";
                return RedirectToAction("Delete", id);
            }
        }
    }
}
