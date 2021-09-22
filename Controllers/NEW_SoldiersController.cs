using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CapstoneProject_MySoldiers_DanWay;

namespace CapstoneProject_MySoldiers_DanWay.Controllers
{
    public class NEW_SoldiersController : Controller
    {
        private readonly dbMySoldiersContext _context;

        public NEW_SoldiersController(dbMySoldiersContext context)
        {
            _context = context;
        }

        // GET: NEW_Soldiers
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSoldiers.ToListAsync());
        }

        // GET: NEW_Soldiers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSoldier = await _context.TbSoldiers
                .FirstOrDefaultAsync(m => m.SoldierId == id);
            if (tbSoldier == null)
            {
                return NotFound();
            }

            return View(tbSoldier);
        }

        // GET: NEW_Soldiers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NEW_Soldiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoldierId,SoldierFname,SoldierMname,SoldierLname,SoldierSuffix,SoldierDob,SoldierAge,SoldierAddress,SoldierCity,SoldierState,SoldierZip,SoldierRole,SoldierBasicEntryDate,SoldierBasicGradDate,SoldierAitEntryDate,SoldierAitGradDate,SoldierEts,SoldierTigYears,SoldierTigMonths,SoldierTisYears,SoldierTisMonths,SoldierSsn,SoldierGender,SoldierCurrRank,SoldierDor,SoldierPebd,SoldierPriMos,SoldierSecMos,SoldierAltMos,SoldierHairColor,SoldierEyeColor,SoldierBloodType,SoldierMaritalStatus,SoldierReligion,SoldierHeight,SoldierWeight,AddDate,AddId,ModDate,ModId")] TbSoldier tbSoldier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSoldier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbSoldier);
        }

        // GET: NEW_Soldiers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSoldier = await _context.TbSoldiers.FindAsync(id);
            if (tbSoldier == null)
            {
                return NotFound();
            }
            return View(tbSoldier);
        }

        // POST: NEW_Soldiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SoldierId,SoldierFname,SoldierMname,SoldierLname,SoldierSuffix,SoldierDob,SoldierAge,SoldierAddress,SoldierCity,SoldierState,SoldierZip,SoldierRole,SoldierBasicEntryDate,SoldierBasicGradDate,SoldierAitEntryDate,SoldierAitGradDate,SoldierEts,SoldierTigYears,SoldierTigMonths,SoldierTisYears,SoldierTisMonths,SoldierSsn,SoldierGender,SoldierCurrRank,SoldierDor,SoldierPebd,SoldierPriMos,SoldierSecMos,SoldierAltMos,SoldierHairColor,SoldierEyeColor,SoldierBloodType,SoldierMaritalStatus,SoldierReligion,SoldierHeight,SoldierWeight,AddDate,AddId,ModDate,ModId")] TbSoldier tbSoldier)
        {
            if (id != tbSoldier.SoldierId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSoldier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbSoldierExists(tbSoldier.SoldierId))
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
            return View(tbSoldier);
        }

        // GET: NEW_Soldiers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSoldier = await _context.TbSoldiers
                .FirstOrDefaultAsync(m => m.SoldierId == id);
            if (tbSoldier == null)
            {
                return NotFound();
            }

            return View(tbSoldier);
        }

        // POST: NEW_Soldiers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSoldier = await _context.TbSoldiers.FindAsync(id);
            _context.TbSoldiers.Remove(tbSoldier);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbSoldierExists(int id)
        {
            return _context.TbSoldiers.Any(e => e.SoldierId == id);
        }
    }
}
