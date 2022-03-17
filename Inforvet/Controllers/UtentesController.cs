#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Inforvet.Areas.Identity.Data;
using Inforvet.Models;
using Microsoft.AspNetCore.Identity;

namespace Inforvet.Controllers
{
    public class UtentesController : Controller
    {
        private readonly InforvetDbContext _context;
        private readonly UserManager<InforvetUser> _userManager;

        public UtentesController(InforvetDbContext context, UserManager<InforvetUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Utentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utente.ToListAsync());
        }

        public async Task<IActionResult> IndexFunc()
        {
            ViewBag.Context = _context;
            return View(await _context.Utente.ToListAsync());
        }

        public async Task<IActionResult> IndexClient()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            List <Utente> utentes = new List<Utente>();
            foreach(Utente utente in _context.Utente.ToList()){
                if(utente.ClienteId.Equals(userId)){
                    utentes.Add(utente);
                }
            }

            return View(utentes);
        }
        // GET: Utentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // GET: Utentes/Create
        public IActionResult Create()
        {
            List<SelectListItem> clientes = new List<SelectListItem>();
            foreach (Cliente cliente in _context.Cliente.ToList()){
                InforvetUser inforvetUser =  _context.Users.Find(cliente.Id);
                clientes.Add(new SelectListItem { Text = inforvetUser.Email, Value = cliente.Id });
            }
            ViewBag.Clientes = clientes;

            return View();
        }

        // POST: Utentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Weight,Race,Sex,State,ClienteId")] Utente utente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(utente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(utente);
        }

        // GET: Utentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            return View(utente);
        }

        public async Task<IActionResult> EditClient(int? id)
        {
            List<SelectListItem> clientes = new List<SelectListItem>();
            InforvetUser inforvetUser = _context.Users.Find(_userManager.GetUserId(HttpContext.User));
            clientes.Add(new SelectListItem { Text = inforvetUser.Email, Value = inforvetUser.Id });
            ViewBag.ClientId = clientes;


            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            return View(utente);
        }

        public async Task<IActionResult> EditFunc(int? id)
        {
            List<SelectListItem> clientes = new List<SelectListItem>();
            foreach (Cliente cliente in _context.Cliente.ToList())
            {
                InforvetUser inforvetUser = _context.Users.Find(cliente.Id);
                clientes.Add(new SelectListItem { Text = inforvetUser.Email, Value = cliente.Id });
            }
            ViewBag.Clientes = clientes;

            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente.FindAsync(id);
            if (utente == null)
            {
                return NotFound();
            }
            return View(utente);
        }

        // POST: Utentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Weight,Race,Sex,State,ClienteId")] Utente utente)
        {
            if (id != utente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(utente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UtenteExists(utente.Id))
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
            return View(utente);
        }

        // GET: Utentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utente = await _context.Utente
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utente == null)
            {
                return NotFound();
            }

            return View(utente);
        }

        // POST: Utentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utente = await _context.Utente.FindAsync(id);
            _context.Utente.Remove(utente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtenteExists(int id)
        {
            return _context.Utente.Any(e => e.Id == id);
        }
    }
}
