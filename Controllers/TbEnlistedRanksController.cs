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
    public class TbEnlistedRanksController : Controller
    {
        private readonly dbMySoldiersContext _context;

        public TbEnlistedRanksController(dbMySoldiersContext context)
        {
            _context = context;
        }

        // GET: TbEnlistedRanks
        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbEnlistedRank.ToListAsync());
        }

        // GET: TbEnlistedRanks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEnlistedRank = await _context.TbEnlistedRank
                .FirstOrDefaultAsync(m => m.EnlistedRankId == id);
            if (tbEnlistedRank == null)
            {
                return NotFound();
            }

            return View(tbEnlistedRank);
        }

        // GET: TbEnlistedRanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TbEnlistedRanks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EnlistedRankId,EnlistedRankPayGrade,EnlistedRankRank,EnlistedRankAbbreviation,EnlistedRankDesc,EnlistedRankInsignia,EnlistedRankIsActive,AddDate,AddId,ModDate,ModId")] TbEnlistedRank tbEnlistedRank)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbEnlistedRank);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbEnlistedRank);
        }

        // GET: TbEnlistedRanks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEnlistedRank = await _context.TbEnlistedRank.FindAsync(id);
            if (tbEnlistedRank == null)
            {
                return NotFound();
            }
            return View(tbEnlistedRank);
        }

        // POST: TbEnlistedRanks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EnlistedRankId,EnlistedRankPayGrade,EnlistedRankRank,EnlistedRankAbbreviation,EnlistedRankDesc,EnlistedRankInsignia,EnlistedRankIsActive,AddDate,AddId,ModDate,ModId")] TbEnlistedRank tbEnlistedRank)
        {
            if (id != tbEnlistedRank.EnlistedRankId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbEnlistedRank);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbEnlistedRankExists(tbEnlistedRank.EnlistedRankId))
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
            return View(tbEnlistedRank);
        }

        // GET: TbEnlistedRanks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEnlistedRank = await _context.TbEnlistedRank
                .FirstOrDefaultAsync(m => m.EnlistedRankId == id);
            if (tbEnlistedRank == null)
            {
                return NotFound();
            }

            return View(tbEnlistedRank);
        }

        // POST: TbEnlistedRanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbEnlistedRank = await _context.TbEnlistedRank.FindAsync(id);
            _context.TbEnlistedRank.Remove(tbEnlistedRank);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbEnlistedRankExists(int id)
        {
            return _context.TbEnlistedRank.Any(e => e.EnlistedRankId == id);
        }
    }
}
