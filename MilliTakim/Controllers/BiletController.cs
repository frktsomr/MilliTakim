using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilliTakim.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MilliTakim.Controllers
{
    [Authorize]
    public class BiletController : Controller
    {
        private readonly WebContext _context;
        public BiletController(WebContext context)
        {
            _context = context;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var webContext = await _context.bilet.ToListAsync();
            ViewData["bilet"] = new Bilet();
            return View(webContext);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BiletEkle(Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bilet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> BiletSil(int? id)
        {
            if (id == null)
            {
                return View("Bulunamadi");
            }
            var _bilet = await _context.bilet.FindAsync(id);
            if (_bilet == null)
            {
                return View("Bulunamadi");
            }
            _context.bilet.Remove(_bilet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> BiletDuzenle(int? id)
        {
            if (id == null)
            {
                return View("Bulunamadi");
            }
            var _bilet = await _context.bilet.FindAsync(id);
            if (_bilet == null)
            {
                return View("Bulunamadi");
            }
            return View(_bilet);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> BiletDuzenle(Bilet bilet, int id)
        {
            if (id != bilet.biletId)
            {
                return View("Bulunamadi");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.biletId))
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


        [HttpGet]
        public async Task<IActionResult> BiletSatinAl(int?id)
        {
            if (id == null)
            {
                return View("Bulunamadi");
            }
            var _bilet = await _context.bilet.FindAsync(id);
            if (_bilet == null)
            {
                return View("Bulunamadi");
            }
            return View(_bilet);
        }

        [HttpPost]
        public async Task<IActionResult> BiletSatinAl(Bilet bilet, int id)
        {
            if (id != bilet.biletId || bilet.biletAdet == 0)
            {
                return View("Bulunamadi");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    bilet.biletAdet = bilet.biletAdet-1;
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.biletId))
                    {
                        return View("Bulunamadi");
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View("SatinAlmaBasarili");
        }


        private bool BiletExists(int id)
        {
            return _context.bilet.Any(e => e.biletId == id);
        }
    }
}

