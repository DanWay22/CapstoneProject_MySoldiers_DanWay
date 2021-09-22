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
    public class TbOfficerRanksController : Controller
    {
        private readonly dbMySoldiersContext _context;

        public TbOfficerRanksController(dbMySoldiersContext context)
        {
            _context = context;
        }

        // GET: TbOfficerRanks
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbOfficerRank.ToListAsync());
        }

        // GET: TbOfficerRanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOfficerRank = await _context.TbOfficerRank
                .FirstOrDefaultAsync(m => m.OfficerRankId == id);
            if (tbOfficerRank == null)
            {
                return NotFound();
            }

            return View(tbOfficerRank);
        }

        // GET: TbOfficerRanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbOfficerRanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OfficerRankId,OfficerRankPayGrade,OfficerRankRank,OfficerRankAbbreviation,OfficerRankDesc,OfficerRankInsignia,OfficerRankIsActive,AddDate,AddId,ModDate,ModId")] TbOfficerRank tbOfficerRank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbOfficerRank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbOfficerRank);
        }

        // GET: TbOfficerRanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOfficerRank = await _context.TbOfficerRank.FindAsync(id);
            if (tbOfficerRank == null)
            {
                return NotFound();
            }
            return View(tbOfficerRank);
        }

        // POST: TbOfficerRanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OfficerRankId,OfficerRankPayGrade,OfficerRankRank,OfficerRankAbbreviation,OfficerRankDesc,OfficerRankInsignia,OfficerRankIsActive,AddDate,AddId,ModDate,ModId")] TbOfficerRank tbOfficerRank)
        {
            if (id != tbOfficerRank.OfficerRankId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbOfficerRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbOfficerRankExists(tbOfficerRank.OfficerRankId))
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
            return View(tbOfficerRank);
        }

        // GET: TbOfficerRanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbOfficerRank = await _context.TbOfficerRank
                .FirstOrDefaultAsync(m => m.OfficerRankId == id);
            if (tbOfficerRank == null)
            {
                return NotFound();
            }

            return View(tbOfficerRank);
        }

        // POST: TbOfficerRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbOfficerRank = await _context.TbOfficerRank.FindAsync(id);
            _context.TbOfficerRank.Remove(tbOfficerRank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbOfficerRankExists(int id)
        {
            return _context.TbOfficerRank.Any(e => e.OfficerRankId == id);
        }
    }
}
