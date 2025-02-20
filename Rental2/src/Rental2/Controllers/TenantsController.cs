using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using Rental2.Models;

namespace Rental2.Controllers
{
    public class TenantsController : Controller
    {
        private RentalContext _context;

        public TenantsController(RentalContext context)
        {
            _context = context;    
        }

        // GET: Tenants
        public IActionResult Index()
        {
            return View(_context.Tenants.ToList());
        }

        // GET: Tenants/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tenant tenant = _context.Tenants
                .Include(m => m.RentalHistory)
                .Single(m => m.ID == id);
            if (tenant == null)
            {
                return HttpNotFound();
            }

            return View(tenant);
        }

        // GET: Tenants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tenants/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                _context.Tenants.Add(tenant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }

        // GET: Tenants/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tenant tenant = _context.Tenants.Single(m => m.ID == id);
            if (tenant == null)
            {
                return HttpNotFound();
            }
            return View(tenant);
        }

        // POST: Tenants/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Tenant tenant)
        {
            if (ModelState.IsValid)
            {
                _context.Update(tenant);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tenant);
        }

        // GET: Tenants/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            Tenant tenant = _context.Tenants.Single(m => m.ID == id);
            if (tenant == null)
            {
                return HttpNotFound();
            }

            return View(tenant);
        }

        // POST: Tenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Tenant tenant = _context.Tenants.Single(m => m.ID == id);
            _context.Tenants.Remove(tenant);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
