using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using EncarnacionCoop.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EncarnacionCoop.Controllers
{
    
    public class CoopController : Controller
    {
        private readonly EncarnacionCoopContext _context;

        public CoopController(EncarnacionCoopContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

         [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UserType b, ClientInfo c)
        {
            _context.UserTypes.Add(b);
            _context.ClientInfos.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            return View(_context.ClientInfos.Where(q=> q.Id == id).FirstOrDefault());
        }

        [HttpPost]
        public IActionResult Update(ClientInfo c, UserType b)
        {
            _context.UserTypes.Add(b);
            _context.ClientInfos.Add(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var c = _context.ClientInfos.Where( q => q.Id == id).FirstOrDefault();
            _context.ClientInfos.Remove(c);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}