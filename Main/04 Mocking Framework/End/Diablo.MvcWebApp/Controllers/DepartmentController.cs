﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Diablo.DataAccessLayer.Models;

using Diablo.DataAccessLayer.Data;

namespace Diablo.MvcWebApp.Controllers
{
    public class DepartmentController : Controller
    {
        private IDepartmentRepository objRepository;
              
        public DepartmentController()
        {           
             this.objRepository = new DepartmentRepository();
        }

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            this.objRepository = departmentRepository;
        }        
        
        //
        // GET: /Department/
        public ActionResult Index()
        {
            List<Department> list = objRepository.List.ToList();

            return View(list);
            
        }

        //
        // GET: /Department/Details/5
        public ActionResult Details(int id = 0)
        {
            if (id < 1)
            {
                ViewBag.Message = "Missing id value";
                return View();
            }
            
            Department department = objRepository.Find(id);
            
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        //
        // GET: /Department/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (department == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                objRepository.Store(department);
           
                return RedirectToAction("Index");
            }

            return View(department);
        }

        //
        // GET: /Department/Edit/5
        public ActionResult Edit(int id = 0)
        {
            if (id < 1)
            {
                return HttpNotFound();
            }
            
            Department department = objRepository.Find(id);

            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        //
        // POST: /Department/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (department == null)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                objRepository.Store(department);
               
                return RedirectToAction("Index");
            }

            return View(department);
        }

        //
        // GET: /Department/Delete/5
        public ActionResult Delete(int id = 0)
        {
            if (id < 1)
            {
                return HttpNotFound();
            }
            
            Department department = objRepository.Find(id);
                       
            if (department == null)
            {
                return HttpNotFound();
            }

            return View(department);
        }

        //
        // POST: /Department/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = objRepository.Find(id);
            objRepository.Delete(id);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            this.objRepository = null;
            base.Dispose(disposing);
        }

    }
}