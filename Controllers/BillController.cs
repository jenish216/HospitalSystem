﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalSystem.Controllers
{
    public class BillController : Controller
    {
        // GET: Bill
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BillList()
        {
            return View();
        }
        public ActionResult BillDetail()
        {
            return View();
        }
    }
}