namespace FitnessLogApp.Models;

public class Exercise
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

      // Add UserId to associate with a user
    public string? UserId { get; set; }
    
}
