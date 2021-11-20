﻿using Microsoft.AspNetCore.Mvc;
using MVCContactsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDApps.DataAccess.EF.Context;

namespace MVCContactsApp.Controllers
{
    public class ContactsController : Controller
    {
        private readonly SQLFundamentalsContext _context;

        public ContactsController(SQLFundamentalsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ContactsViewModel model = new ContactsViewModel(_context);
            return View(model);
        }

        [HttpPost]
        public IActionResult Index(int contactID, string firstName, string lastName, string phoneNumber, string emailAddress)
        {
            ContactsViewModel model = new ContactsViewModel(_context);
            model.SaveContact(contactID, firstName, lastName, phoneNumber, emailAddress);
            model.IsActionSuccess = true;
            model.ActionMessage = "Contact has been saved successfully";

            return View(model);
        }

        public IActionResult Update(int id)
        {
            ContactsViewModel model = new ContactsViewModel(_context, id);
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            ContactsViewModel model = new ContactsViewModel(_context);

            if (id > 0)
            {
                model.RemoveContact(id);
            }
            
            model.IsActionSuccess = true;
            model.ActionMessage = "Contact has been deleted successfully";
            return View("Index", model);
        }
    }
}
