using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SoundEffect.Data;

namespace SoundEffect.Controllers
{
    [Authorize]
    public class ShoppingCartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<Client> _userManager;

        public ShoppingCartsController(ApplicationDbContext context, UserManager<Client> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: ShoppingCarts
        public async Task<IActionResult> Index()
        {
           
            if (User.IsInRole("Admin"))
            {
                var applicationDbContext = _context.ShoppingCarts.Include(s => s.Clients).Include(s => s.Items);
                return View(await applicationDbContext.ToListAsync());

            }
            else
            {
                var currentUser = _userManager.GetUserId(User);
                var myOrders = _context.ShoppingCarts
                               .Include(o => o.Items)
                               .Include(u => u.Clients)
                               .Where(x => x.ClientId == currentUser.ToString())
                               .ToListAsync();

                return View(await myOrders);
            }
        }

        // GET: ShoppingCarts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ShoppingCarts == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCarts
                .Include(s => s.Clients)
                .Include(s => s.Items)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Create
        public IActionResult Create(int? itemId)
        {
            ShoppingCart shoppingCart = new ShoppingCart();
            if (itemId != null)
            {
                shoppingCart.ItemId = (int)itemId;
            }
           
        //    ViewData["ClientId"] = new SelectList(_context.Users, "Id", "Id");
        //    ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Id");
         return View(shoppingCart);
        }

        // POST: ShoppingCarts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,ItemId,Quantity,DateOfOrder")] ShoppingCart shoppingCart)
        {
            if (ModelState.IsValid)
            {
                //decimal currentPrice = _context.Items.Find(n => n.Id == shoppingCart.ItemId).Price;
                //shoppingCart. = shoppingCart.Quantity * currentPrice; //+ _context.ShoppingCarts.Include(x => x.Items)
                   // .Where(x => x.Id == shoppingCart.ItemId).Select(x => x);
                shoppingCart.DateOfOrder = DateTime.Now;
                shoppingCart.ClientId = _userManager.GetUserId(User);
                _context.Add(shoppingCart);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //ViewData["ClientId"] = new SelectList(_context.Users, "Id", "Id", shoppingCart.ClientId);
            //shoppingCart.ClientId = _userManager.GetUserId(User);
            //ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", shoppingCart.ItemId);
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ShoppingCarts == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }
            shoppingCart.ClientId = _userManager.GetUserId(User);
            //ViewData["ClientId"] = new SelectList(_context.Users, "Id", "Name", shoppingCart.ClientId);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", shoppingCart.ItemId);
            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,ItemId,Quantity")] ShoppingCart shoppingCart)
        {
            if (id != shoppingCart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    shoppingCart.ClientId = _userManager.GetUserId(User);
                    shoppingCart.DateOfOrder = DateTime.Now;
                    _context.ShoppingCarts.Update(shoppingCart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoppingCartExists(shoppingCart.Id))
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

            //ViewData["ClientId"] = new SelectList(_context.Users, "Id", "Id", shoppingCart.ClientId);
            shoppingCart.ClientId = _userManager.GetUserId(User);
            ViewData["ItemId"] = new SelectList(_context.Items, "Id", "Name", shoppingCart.ItemId);
            return View(shoppingCart);
        }

        // GET: ShoppingCarts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ShoppingCarts == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCarts
                .Include(s => s.Clients)
                .Include(s => s.Items)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        // POST: ShoppingCarts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ShoppingCarts == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ShoppingCarts'  is null.");
            }
            var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            if (shoppingCart != null)
            {
                _context.ShoppingCarts.Remove(shoppingCart);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.Id == id);
        }
    }
}
