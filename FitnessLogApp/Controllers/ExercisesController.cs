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
    public class ExercisesController : Controller
    {
        private readonly IExerciseService _exerciseService;
        private readonly UserManager<IdentityUser> _userManager;

        public ExercisesController(IExerciseService exerciseService, UserManager<IdentityUser> userManager)
        {
            _exerciseService = exerciseService;
            _userManager = userManager;
        }

        // GET: Exercises
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            return View(await _exerciseService.GetExercisesAsync(userId));
        }

        // GET: Exercises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var exercise = await _exerciseService.GetExerciseByIdAsync(id.Value, userId);

            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // GET: Exercises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Exercises/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Exercise exercise)
        {
            if (ModelState.IsValid)
            {
                exercise.UserId = _userManager.GetUserId(User);
                await _exerciseService.CreateExerciseAsync(exercise);
                return RedirectToAction(nameof(Index));
            }
            return View(exercise);
        }

        // GET: Exercises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var exercise = await _exerciseService.GetExerciseByIdAsync(id.Value, userId);

            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description")] Exercise exercise)
        {
            if (id != exercise.Id)
            {
                return NotFound();
            }

            exercise.UserId = _userManager.GetUserId(User);

            if (ModelState.IsValid)
            {
                await _exerciseService.UpdateExerciseAsync(exercise);
                return RedirectToAction(nameof(Index));
            }

            return View(exercise);
        }

        // GET: Exercises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userId = _userManager.GetUserId(User);
            var exercise = await _exerciseService.GetExerciseByIdAsync(id.Value, userId);

            if (exercise == null)
            {
                return NotFound();
            }

            return View(exercise);
        }

        // POST: Exercises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userId = _userManager.GetUserId(User);
            await _exerciseService.DeleteExerciseAsync(id, userId);
            return RedirectToAction(nameof(Index));
        }
    }
}