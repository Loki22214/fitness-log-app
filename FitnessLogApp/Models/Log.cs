namespace FitnessLogApp.Models;

public class Log
{
    public int Id { get; set; }
    public int Sets { get; set; }
    public int Reps { get; set; }
    public decimal Weight { get; set; }
    public DateTime Date { get; set; }

    // Add UserId to associate with a user
    public string? UserId { get; set; }
   

    public int ExerciseId { get; set; }
    public Exercise? Exercise { get; set; }
}