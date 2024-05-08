using FinalProjectASP.Data;
using FinalProjectASP.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectASP.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContex _context;

        public CustomerController(ApplicationDbContex context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return _context.ApplicationUser != null ?
                        View(await _context.ApplicationUser.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContex.ApplicationUser'  is null.");
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(string first)
        {
            if (first == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var Customer = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Firstname == first);
            if (Customer == null)
            {
                return NotFound();
            }
            return View(Customer);
        }

        public async Task<IActionResult> Edit(string? email)
        {
            if (email == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }


            var product = await _context.ApplicationUser.FindAsync(email);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string email, [Bind("Firstname,Lastname,Email")] ApplicationUser Appuser)
        {
            if (email != Appuser.Email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Appuser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(Appuser.Email))
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
            return View(Appuser);
        }

        public async Task<IActionResult> Delete(string email)
        {
            if (email == null || _context.ApplicationUser == null)
            {
                return NotFound();
            }

            var customer = await _context.ApplicationUser
                .FirstOrDefaultAsync(m => m.Email == email);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string email)
        {
            if (_context.ApplicationUser == null)
            {
                return Problem("Entity set 'ApplicationDbContex.ApplicationUser'  is null.");
            }
            var customer = await _context.ApplicationUser.FindAsync(email);
            if (customer != null)
            {
                _context.ApplicationUser.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string email)
        {
            return (_context.ApplicationUser?.Any(e => e.Email == email)).GetValueOrDefault();
        }
    }
}
