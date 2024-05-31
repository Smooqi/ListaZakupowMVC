using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ListaZakupowMVC.Data;
using ListaZakupowMVC.Models;

namespace ListaZakupowMVC.Controllers
{
    public class ListaZakupowController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListaZakupowController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ListaZakupow
        public async Task<IActionResult> Index()
        {
            var listaZakupow = await _context.ListaZakupow.ToListAsync();
            return View(listaZakupow);
        }

        // GET: ListaZakupow/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaZakupow = await _context.ListaZakupow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaZakupow == null)
            {
                return NotFound();
            }

            return View(listaZakupow);
        }

        // GET: ListaZakupow/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ListaZakupow/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,isSet")] ListaZakupow listaZakupow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listaZakupow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(listaZakupow);
        }

        // GET: ListaZakupow/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaZakupow = await _context.ListaZakupow.FindAsync(id);
            if (listaZakupow == null)
            {
                return NotFound();
            }
            return View(listaZakupow);
        }

        // POST: ListaZakupow/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,isSet")] ListaZakupow listaZakupow)
        {
            if (id != listaZakupow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listaZakupow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListaZakupowExists(listaZakupow.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(listaZakupow);
        }

        [HttpPost, ActionName("Check")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Check(int id)
        {
             var listaZakupow =  await _context.ListaZakupow.FindAsync(id);
            //var listaZakupow = lista;
           
            if (listaZakupow != null)
            {
                if(!listaZakupow.IsSet)
                {
                    listaZakupow.IsSet = true;
                    _context.Update(listaZakupow);
                    await _context.SaveChangesAsync();
                }
                else
                    return BadRequest("Już odznaczone");
            }
            else
            {
                return NotFound();
            }

            return RedirectToAction("Index");


        }


        // GET: ListaZakupow/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listaZakupow = await _context.ListaZakupow
                .FirstOrDefaultAsync(m => m.Id == id);
            if (listaZakupow == null)
            {
                return NotFound();
            }

            return View(listaZakupow);
        }

        // POST: ListaZakupow/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listaZakupow = await _context.ListaZakupow.FindAsync(id);
            if (listaZakupow != null)
            {
                _context.ListaZakupow.Remove(listaZakupow);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListaZakupowExists(int id)
        {
            return _context.ListaZakupow.Any(e => e.Id == id);
        }
    }
}
