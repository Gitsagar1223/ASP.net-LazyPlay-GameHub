using FinalProjectASP.Data;
using FinalProjectASP.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProjectASP.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContex _context;

        public OrderController(ApplicationDbContex context)
        {
            _context = context;
        }


        // GET: OrderController
        public async Task<IActionResult> Index()
        {
            return _context.orders != null ?
                        View(await _context.orders.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContex.orders'  is null.");
        }

        public async Task<IActionResult> getDetails(int id)
        {
            if (id == null || _context.products == null)
            {
                return NotFound();
            }

            var product = await _context.products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderController/Create
        
        public async Task<IActionResult> Create([Bind("orderId,productId,productName,productPrice,userName")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: OrderController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.orders == null)
            {
                return NotFound();
            }

            var order = await _context.orders
                .FirstOrDefaultAsync(m => m.orderId == id);
            if (order == null)
            {
                return NotFound();
            }
            _context.orders.Remove(order);
            return View(order);
            
        }

    }
}
