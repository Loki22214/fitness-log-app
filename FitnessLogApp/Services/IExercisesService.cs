using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessLogApp.Models;

namespace FitnessLogApp.Services
{
    public interface IExerciseService
    {
        Task<IEnumerable<Exercise>> GetExercisesAsync(string userId);
        Task<Exercise> GetExerciseByIdAsync(int id, string userId);
        Task CreateExerciseAsync(Exercise exercise);
        Task UpdateExerciseAsync(Exercise exercise);
        Task DeleteExerciseAsync(int id, string userId);
        Task<bool> ExerciseExistsAsync(int id);
    }
}