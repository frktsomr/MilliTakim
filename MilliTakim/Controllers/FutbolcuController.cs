using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilliTakim.Models;
using Microsoft.EntityFrameworkCore;

namespace MilliTakim.Controllers
{
    public class FutbolcuController : Controller
    {
        private readonly WebContext _context;
        public FutbolcuController(WebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var webContext = await _context.futbolcu.ToListAsync();
            ViewData["futbolcu"] = new Futbolcu();
            return View(webContext);
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FutbolcuEkle(Futbolcu futbolcu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(futbolcu);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FutbolcuSil(int?id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var _futbolcu = await _context.futbolcu.FindAsync(id);
            if(_futbolcu == null)
            {
                return NotFound();
            }
            _context.futbolcu.Remove(_futbolcu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
