﻿using DIYComputer.Entity.DBContext;
using DIYComputer.Entity.SysEntity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DIYComputer.WebBackend.Controllers.ComputerGroupControllers
{
    [Authorize(Policy = "Admin")]
    public class ComputersController : Controller
    {
        private readonly EFDBContext _context;

        public ComputersController(EFDBContext context)
        {
            _context = context;
        }

        // GET: Computers
        public async Task<IActionResult> Index()
        {
            var result = await _context.Computers.ToListAsync();

            foreach (var item in result)
            {
                item.Case = _context.Cases.FirstOrDefault(o => o.ID == item.CaseId);
                item.CDROM = _context.CDROMs.FirstOrDefault(o => o.ID == item.CDROMId);
                item.CPU = _context.CPUs.FirstOrDefault(o => o.ID == item.CPUId);
                item.CPUHS = _context.CPUHs.FirstOrDefault(o => o.ID == item.CPUHSId);
                item.Display = _context.Displays.FirstOrDefault(o => o.ID == item.DisplayId);
                item.Graphyic = _context.Graphyics.FirstOrDefault(o => o.ID == item.GraphyicId);
                item.HardDisk = _context.HardDisks.FirstOrDefault(o => o.ID == item.HardDiskId);
                item.Mainboard = _context.Mainboards.FirstOrDefault(o => o.ID == item.MainboardId);
                item.NetWork = _context.NetWorks.FirstOrDefault(o => o.ID == item.NetWorkId);
                item.Power = _context.Powers.FirstOrDefault(o => o.ID == item.PowerId);
                item.ROM = _context.ROMs.FirstOrDefault(o => o.ID == item.ROMId);
                item.SSD = _context.SSDs.FirstOrDefault(o => o.ID == item.SSDId);
            }
            return View(result);
        }

        // GET: Computers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computers
                .FirstOrDefaultAsync(m => m.Id == id);

            computer.Case = _context.Cases.FirstOrDefault(o => o.ID == computer.CaseId);
            computer.CDROM = _context.CDROMs.FirstOrDefault(o => o.ID == computer.CDROMId);
            computer.CPU = _context.CPUs.FirstOrDefault(o => o.ID == computer.CPUId);
            computer.CPUHS = _context.CPUHs.FirstOrDefault(o => o.ID == computer.CPUHSId);
            computer.Display = _context.Displays.FirstOrDefault(o => o.ID == computer.DisplayId);
            computer.Graphyic = _context.Graphyics.FirstOrDefault(o => o.ID == computer.GraphyicId);
            computer.HardDisk = _context.HardDisks.FirstOrDefault(o => o.ID == computer.HardDiskId);
            computer.Mainboard = _context.Mainboards.FirstOrDefault(o => o.ID == computer.MainboardId);
            computer.NetWork = _context.NetWorks.FirstOrDefault(o => o.ID == computer.NetWorkId);
            computer.Power = _context.Powers.FirstOrDefault(o => o.ID == computer.PowerId);
            computer.ROM = _context.ROMs.FirstOrDefault(o => o.ID == computer.ROMId);
            computer.SSD = _context.SSDs.FirstOrDefault(o => o.ID == computer.SSDId);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // GET: Computers/Create
        public IActionResult Create()
        {

            return View(new Computer());
        }

        // POST: Computers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreateTime,EditTime,Remarks,PlanName" +
                                                      "CaseId，" +
                                                      "CDROMId," +
                                                      "CPUId," +
                                                      "CPUHSId," +
                                                      "DisplayId," +
                                                      "GraphyicId," +
                                                      "HardDiskId," +
                                                      "MainboardId," +
                                                      "NetWorkId," +
                                                      "PowerId," +
                                                      "ROMId," +
                                                      "ValueSum"+
                                                      "SSDId")] Computer computer)
        {

            computer.ValueSum = Convert.ToInt32(HttpContext.Request.Form["ValueSum"]);
            computer.CDROMId = Convert.ToInt32(HttpContext.Request.Form["CDROMId"]);
            computer.CaseId = Convert.ToInt32(HttpContext.Request.Form["CaseId"]);
            computer.UserID = 1;//默认管理员为账户1
            if (ModelState.IsValid)
            {
                _context.Add(computer);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(computer);
        }

        // GET: Computers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computers.FindAsync(id);

            computer.Case = _context.Cases.FirstOrDefault(o => o.ID == computer.CaseId);
            computer.CDROM = _context.CDROMs.FirstOrDefault(o => o.ID == computer.CDROMId);
            computer.CPU = _context.CPUs.FirstOrDefault(o => o.ID == computer.CPUId);
            computer.CPUHS = _context.CPUHs.FirstOrDefault(o => o.ID == computer.CPUHSId);
            computer.Display = _context.Displays.FirstOrDefault(o => o.ID == computer.DisplayId);
            computer.Graphyic = _context.Graphyics.FirstOrDefault(o => o.ID == computer.GraphyicId);
            computer.HardDisk = _context.HardDisks.FirstOrDefault(o => o.ID == computer.HardDiskId);
            computer.Mainboard = _context.Mainboards.FirstOrDefault(o => o.ID == computer.MainboardId);
            computer.NetWork = _context.NetWorks.FirstOrDefault(o => o.ID == computer.NetWorkId);
            computer.Power = _context.Powers.FirstOrDefault(o => o.ID == computer.PowerId);
            computer.ROM = _context.ROMs.FirstOrDefault(o => o.ID == computer.ROMId);
            computer.SSD = _context.SSDs.FirstOrDefault(o => o.ID == computer.SSDId);

            if (computer == null)
            {
                return NotFound();
            }
            return View(computer);
        }

        // POST: Computers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CreateTime,EditTime,Remarks," +
                                                            "CaseId，" +
                                                            "CDROMId," +
                                                            "CPUId," +
                                                            "CPUHSId," +
                                                            "DisplayId," +
                                                            "GraphyicId," +
                                                            "HardDiskId," +
                                                            "MainboardId," +
                                                            "NetWorkId," +
                                                            "PowerId," +
                                                            "ROMId," +
                                                            "ValueSum"+
                                                            "SSDId")] Computer computer)
        {
            if (id != computer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(computer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComputerExists(computer.Id))
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
            return View(computer);
        }

        // GET: Computers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computer = await _context.Computers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (computer == null)
            {
                return NotFound();
            }

            return View(computer);
        }

        // POST: Computers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var computer = await _context.Computers.FindAsync(id);
            _context.Computers.Remove(computer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComputerExists(int id)
        {
            return _context.Computers.Any(e => e.Id == id);
        }
    }
}
