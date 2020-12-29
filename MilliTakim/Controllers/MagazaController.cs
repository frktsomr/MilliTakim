using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilliTakim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Controllers
{
    public class MagazaController : Controller
    {
        private readonly WebContext _context;
        public MagazaController(WebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var webContext = await _context.magaza.ToListAsync();
            ViewData["magaza"] = new Magaza();
            return View(webContext);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MagazaUrunEkle(Magaza magaza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(magaza);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public IActionResult MagazaSatinAl()
        {
            return View();
        }
    }
}
