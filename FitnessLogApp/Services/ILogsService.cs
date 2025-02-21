using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessLogApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitnessLogApp.Services
{
    public interface ILogService
    {
        Task<IEnumerable<Log>> GetLogsAsync(string userId);
        Task<Log> GetLogByIdAsync(int id, string userId);
        Task CreateLogAsync(Log log);
        Task UpdateLogAsync(Log log);
        Task DeleteLogAsync(int id, string userId);
        Task<bool> LogExistsAsync(int id);
        Task<IEnumerable<SelectListItem>> GetExercisesForUserAsync(string userId);
    }
}