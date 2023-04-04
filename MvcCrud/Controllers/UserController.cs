using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCrud.Models;

namespace MvcCrud.Controllers
{
    public class UserController : Controller
    {
        // GET: User/Index
        public ActionResult Index()
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.User.ToList());
            }

        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.User.Where(x => x.Id == id).FirstOrDefault());
            }

        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.User.Add(user);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.User.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    dbModel.Entry(user).State = EntityState.Modified;
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels dbModel = new DbModels())
            {
                return View(dbModel.User.Where(x => x.Id == id).FirstOrDefault());
            }
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels dbModel = new DbModels())
                {
                    User user = dbModel.User.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.User.Remove(user);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
