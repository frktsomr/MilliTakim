using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MilliTakim.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.IO;

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
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        futbolcu.ProfilePicture = dataStream.ToArray();
                    }
                }
                _context.Add(futbolcu);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FutbolcuSil(int? id)
        {
            if (id == null)
            {
                return View("Bulunamadi");
            }
            var _futbolcu = await _context.futbolcu.FindAsync(id);
            if (_futbolcu == null)
            {
                return View("Bulunamadi");
            }
            _context.futbolcu.Remove(_futbolcu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> FutbolcuDuzenle(int? id)
        {
            if (id == null)
            {
                return View("Bulunamadi");
            }
            var _futbolcu = await _context.futbolcu.FindAsync(id);
            if (_futbolcu == null)
            {
                return View("Bulunamadi");
            }
            return View(_futbolcu);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> FutbolcuDuzenle(Futbolcu futbolcu,int id)
        {
            if (id != futbolcu.playerId)
            {
                return View("Bulunamadi");
            }
            if (ModelState.IsValid)
            {
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        futbolcu.ProfilePicture = dataStream.ToArray();
                    }
                }
                try
                {
                    _context.Update(futbolcu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FutbolcuExists(futbolcu.playerId))
                    {
                        return View("Bulunamadi");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FutbolcuExists(int id)
        {
            return _context.futbolcu.Any(e => e.playerId == id);
        }
    }
}
