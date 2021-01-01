using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilliTakim.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                if (Request.Form.Files.Count > 0)
                {
                    IFormFile file = Request.Form.Files.FirstOrDefault();
                    using (var dataStream = new MemoryStream())
                    {
                        await file.CopyToAsync(dataStream);
                        magaza.ProfilePicture = dataStream.ToArray();
                    }
                }
                _context.Add(magaza);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize]
        public IActionResult MagazaSatinAl(int fiyat)
        {
            ViewBag.total = fiyat;
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult MagazaSatinAl()
        {
            return View("SatinAlmaBasarili");
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> MagazaDuzenle(int? id)
        {
            if (id == null)
            {
                return View("Bulunamadi");
            }
            var _magaza = await _context.magaza.FindAsync(id);
            if (_magaza == null)
            {
                return View("Bulunamadi");
            }
            return View(_magaza);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> MagazaDuzenle(Magaza magaza, int id)
        {
            if (id != magaza.urunId)
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
                        magaza.ProfilePicture = dataStream.ToArray();
                    }
                }
                try
                {
                    _context.Update(magaza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MagazaExists(magaza.urunId))
                    {
                        return View("Bulunamadi");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MagazaSil(int? id)
        {
            if (id == null)
            {
                return View("Bulunamadi");
            }
            var _magaza = await _context.magaza.FindAsync(id);
            if (_magaza == null)
            {
                return View("Bulunamadi");
            }
            _context.magaza.Remove(_magaza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        private bool MagazaExists(int id)
        {
            return _context.magaza.Any(e => e.urunId == id);
        }

    }
}
