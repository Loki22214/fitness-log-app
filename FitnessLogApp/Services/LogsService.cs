using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessLogApp.Data;
using FitnessLogApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessLogApp.Services
{
    public class LogService : ILogService
    {
        private readonly ApplicationDbContext _context;

        public LogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Log>> GetLogsAsync(string userId)
        {
            return await _context.Log
                .Where(l => l.UserId == userId)
                .ToListAsync();
        }

        public async Task<Log> GetLogByIdAsync(int id, string userId)
        {
            return await _context.Log
                .Where(l => l.UserId == userId && l.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task CreateLogAsync(Log log)
        {
            _context.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateLogAsync(Log log)
        {
            _context.Update(log);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteLogAsync(int id, string userId)
        {
            var log = await _context.Log
                .Where(l => l.UserId == userId && l.Id == id)
                .FirstOrDefaultAsync();

            if (log != null)
            {
                _context.Log.Remove(log);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> LogExistsAsync(int id)
        {
            return await _context.Log.AnyAsync(l => l.Id == id);
        }

        public async Task<IEnumerable<SelectListItem>> GetExercisesForUserAsync(string userId)
        {
            return await _context.Exercise
                .Where(e => e.UserId == userId)
                .Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name
                })
                .ToListAsync();
        }
    }
}