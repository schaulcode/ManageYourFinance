﻿using ManageYourFinance.App.Models;
using ManageYourFinance.Data.Services;
using System;
using System.Collections.Generic;
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
            var data = db.GetAll();
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
            var transactionsData = new SqlDataServices<Data.Models.Transactions>().GetAll(model.ID, typeof(Data.Models.Category));
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
