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
    public class TbSoldiersController : Controller
    {
        private readonly dbMySoldiersContext _context;

        public TbSoldiersController(dbMySoldiersContext context)
        {
            _context = context;
        }

        // GET: TbSoldiers
        //[Authorize]
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.TbSoldiers.ToListAsync());
        //}

        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSoldiers.ToListAsync());
        }


        // GET: TbSoldiers/Details/5
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

        // GET: TbSoldiers/Create
        public IActionResult Create()
        {
            return View();
        }

        //Get TbSoldiers/Create_P2
        public IActionResult Create_P2()
        {
            return View();
        }

        // POST: TbSoldiers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SoldierId,SoldierFname,SoldierMname,SoldierLname,SoldierSuffix,SoldierDob,SoldierAge,SoldierAddress,SoldierCity,SoldierState,SoldierZip,SoldierRole,SoldierBasicEntryDate,SoldierBasicGradDate,SoldierAitEntryDate,SoldierAitGradDate,SoldierEts,SoldierTigYears,SoldierTigMonths,SoldierTisYears,SoldierTisMonths,SoldierSsn,SoldierGender,SoldierCurrRank,SoldierDor,SoldierPebd,SoldierPriMos,SoldierSecMos,SoldierAltMos,SoldierHairColor,SoldierEyeColor,SoldierBloodType,SoldierMaritalStatus,SoldierRegligion,SoldierHeight,SoldierWeight,AddDate,AddId,ModDate,ModId")] TbSoldier tbSoldier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSoldier);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Edit_P2");
                return RedirectToAction("Create_P2", new { SoldierId = tbSoldier.SoldierId });
            }
            return View(tbSoldier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create_P2([Bind("SoldierId,SoldierFname,SoldierMname,SoldierLname,SoldierSuffix,SoldierDob,SoldierAge,SoldierAddress,SoldierCity,SoldierState,SoldierZip,SoldierRole,SoldierBasicEntryDate,SoldierBasicGradDate,SoldierAitEntryDate,SoldierAitGradDate,SoldierEts,SoldierTigYears,SoldierTigMonths,SoldierTisYears,SoldierTisMonths,SoldierSsn,SoldierGender,SoldierCurrRank,SoldierDor,SoldierPebd,SoldierPriMos,SoldierSecMos,SoldierAltMos,SoldierHairColor,SoldierEyeColor,SoldierBloodType,SoldierMaritalStatus,SoldierRegligion,SoldierHeight,SoldierWeight,AddDate,AddId,ModDate,ModId")] TbSoldier tbSoldier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSoldier);
                await _context.SaveChangesAsync();
                //return RedirectToAction("Edit_P2", new { SoldierId = tbSoldier.SoldierId });
                return RedirectToAction(nameof(Index));
            }
            return View(tbSoldier);
        }

        // GET: TbSoldiers/Edit/5
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

        // GET: TbSoldiers/Edit/5
        public async Task<IActionResult> Edit_P2(int? id)
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

        // POST: TbSoldiers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit(int id, [Bind("SoldierId,SoldierFname,SoldierMname,SoldierLname,SoldierSuffix,SoldierDob,SoldierAge,SoldierAddress,SoldierCity,SoldierState,SoldierZip,SoldierRole,SoldierBasicEntryDate,SoldierBasicGradDate,SoldierAitEntryDate,SoldierAitGradDate,SoldierEts,SoldierTigYears,SoldierTigMonths,SoldierTisYears,SoldierTisMonths,SoldierSsn,SoldierGender,SoldierCurrRank,SoldierDor,SoldierPebd,SoldierPriMos,SoldierSecMos,SoldierAltMos,SoldierHairColor,SoldierEyeColor,SoldierBloodType,SoldierMaritalStatus,SoldierRegligion,SoldierHeight,SoldierWeight,AddDate,AddId,ModDate,ModId")] TbSoldier tbSoldier)
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
                //return RedirectToAction("Edit_P2", new { SoldierId = tbSoldier.SoldierId });
                return RedirectToAction("Edit_P2");
            }
            return View(tbSoldier);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Edit_P2(int id, [Bind("SoldierId,SoldierFname,SoldierMname,SoldierLname,SoldierSuffix,SoldierDob,SoldierAge,SoldierAddress,SoldierCity,SoldierState,SoldierZip,SoldierRole,SoldierBasicEntryDate,SoldierBasicGradDate,SoldierAitEntryDate,SoldierAitGradDate,SoldierEts,SoldierTigYears,SoldierTigMonths,SoldierTisYears,SoldierTisMonths,SoldierSsn,SoldierGender,SoldierCurrRank,SoldierDor,SoldierPebd,SoldierPriMos,SoldierSecMos,SoldierAltMos,SoldierHairColor,SoldierEyeColor,SoldierBloodType,SoldierMaritalStatus,SoldierRegligion,SoldierHeight,SoldierWeight,AddDate,AddId,ModDate,ModId")] TbSoldier tbSoldier)
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

                //return RedirectToAction("Edit_P2", new { SoldierId = tbSoldier.SoldierId });
                return RedirectToAction(nameof(Index));
            }
            return View(tbSoldier);
        }

        // GET: TbSoldiers/Delete/5
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


        //[NonAction]
        //public SelectList ToSelectList(List<Usstate> listState)
        //{
        //    List<SelectListItem> list = new List<SelectListItem>();

        //    foreach (Usstate item in listState)
        //    {
        //        list.Add(new SelectListItem()
        //        {
        //            Text = item.Title,
        //            Value = Convert.ToString(item.SkillID)
        //        });
        //    }

        //    return new SelectList(list, "Value", "Text");
        //}


        // POST: TbSoldiers/Delete/5
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
