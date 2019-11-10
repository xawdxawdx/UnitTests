using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using magazin.Models;
using Microsoft.EntityFrameworkCore;

namespace magazin.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            return View(db.Phones.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {

            ViewBag.PhoneId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                // сохраняем в бд все изменения
                db.SaveChanges();
                return "Спасибо, " + order.User + ", за покупку!";
            }
            else return "Nope";
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Phone phone)
        {
            if (ModelState.IsValid)
            {
                db.Phones.Add(phone);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
                return View(phone);
        }

        public IActionResult Details(int? id)
        {
            if (id != null)
            {
                Phone phone = db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        public IActionResult Edit(int? id)
        {
            if (id != null)
            {
                Phone phone = db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Phone phone)
        {
            db.Phones.Update(phone);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Phone phone = db.Phones.FirstOrDefault(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = new Phone { Id = id.Value };
                db.Entry(phone).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }





        [AcceptVerbs("Get", "Post")]
        public IActionResult CheckCompany(string company)
        {
            if (company.ToLower() == "huawei")
                return Json(false);
            return Json(true);
        }
    }
}
