using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneProject_MySoldiers_DanWay;
using Microsoft.AspNetCore.Authorization;

namespace CapstoneProject_MySoldiers_DanWay.Controllers
{
    public class TbRolesController : Controller
    {
        private readonly dbMySoldiersContext _context;

        public TbRolesController(dbMySoldiersContext context)
        {
            _context = context;
        }

        // GET: TbRoles
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbRole.ToListAsync());
        }

        // GET: TbRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbRole = await _context.TbRole
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tbRole == null)
            {
                return NotFound();
            }

            return View(tbRole);
        }

        // GET: TbRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoleId,RoleName,RoleDesc,RoleIsActive,AddDate,AddId,ModDate,ModId")] TbRole tbRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbRole);
        }

        // GET: TbRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbRole = await _context.TbRole.FindAsync(id);
            if (tbRole == null)
            {
                return NotFound();
            }
            return View(tbRole);
        }

        // POST: TbRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoleId,RoleName,RoleDesc,RoleIsActive,AddDate,AddId,ModDate,ModId")] TbRole tbRole)
        {
            if (id != tbRole.RoleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbRoleExists(tbRole.RoleId))
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
            return View(tbRole);
        }

        // GET: TbRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbRole = await _context.TbRole
                .FirstOrDefaultAsync(m => m.RoleId == id);
            if (tbRole == null)
            {
                return NotFound();
            }

            return View(tbRole);
        }

        // POST: TbRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbRole = await _context.TbRole.FindAsync(id);
            _context.TbRole.Remove(tbRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbRoleExists(int id)
        {
            return _context.TbRole.Any(e => e.RoleId == id);
        }
    }
}
