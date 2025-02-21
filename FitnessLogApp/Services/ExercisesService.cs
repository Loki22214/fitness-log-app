using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessLogApp.Data;
using FitnessLogApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessLogApp.Services
{
    public class ExerciseService : IExerciseService
    {
        private readonly ApplicationDbContext _context;

        public ExerciseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> GetExercisesAsync(string userId)
        {
            return await _context.Exercise
                .Where(e => e.UserId == userId)
                .ToListAsync();
        }

        public async Task<Exercise> GetExerciseByIdAsync(int id, string userId)
        {
            return await _context.Exercise
                .Where(e => e.UserId == userId && e.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task CreateExerciseAsync(Exercise exercise)
        {
            _context.Add(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateExerciseAsync(Exercise exercise)
        {
            _context.Update(exercise);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteExerciseAsync(int id, string userId)
        {
            var exercise = await _context.Exercise
                .Where(e => e.UserId == userId && e.Id == id)
                .FirstOrDefaultAsync();

            if (exercise != null)
            {
                _context.Exercise.Remove(exercise);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExerciseExistsAsync(int id)
        {
            return await _context.Exercise.AnyAsync(e => e.Id == id);
        }
    }
}