﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopService.Controllers
{
    public class CreditCardController : Controller
    {
        // GET: CreditCardController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CreditCardController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CreditCardController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CreditCardController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreditCardController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CreditCardController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CreditCardController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CreditCardController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
