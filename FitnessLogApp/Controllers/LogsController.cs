using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FitnessLogApp.Data;
using FitnessLogApp.Models;
using FitnessLogApp.Services;

namespace FitnessLogApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly ILogService _logService;
        private readonly UserManager<IdentityUser> _userManager;

        public LogsController(ILogService logService, UserManager<IdentityUser> userManager)
        {
            _logService = logService;
            _userManager = userManager;
        }

        // GET: Logs
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            return View(await _logService.GetLogsAsync(userId));
        }

        // GET: Logs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var log = await _logService.GetLogByIdAsync(id.Value, userId);

            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // GET: Logs/Create
        public async Task<IActionResult> Create()
        {
            var userId = _userManager.GetUserId(User);
            ViewBag.Exercises = await _logService.GetExercisesForUserAsync(userId);
            return View();
        }

        // POST: Logs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Sets,Reps,Weight,Date,ExerciseId")] Log log)
        {
            if (ModelState.IsValid)
            {
                log.UserId = _userManager.GetUserId(User);
                await _logService.CreateLogAsync(log);
                return RedirectToAction(nameof(Index));
            }

            var userId = _userManager.GetUserId(User);
            ViewBag.Exercises = await _logService.GetExercisesForUserAsync(userId);
            return View(log);
        }

        // GET: Logs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var log = await _logService.GetLogByIdAsync(id.Value, userId);

            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Logs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sets,Reps,Weight,Date,ExerciseId")] Log log)
        {
            if (id != log.Id)
            {
                return NotFound();
            }

            log.UserId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                await _logService.UpdateLogAsync(log);
                return RedirectToAction(nameof(Index));
            }

            return View(log);
        }

        // GET: Logs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var log = await _logService.GetLogByIdAsync(id.Value, userId);

            if (log == null)
            {
                return NotFound();
            }

            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _logService.DeleteLogAsync(id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}