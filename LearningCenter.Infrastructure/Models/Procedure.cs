namespace LearningCenter.Infrastructure.Models;

public class Procedure
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
        
    // Navigation properties (if needed)
    public Category Category { get; set; }
    //public Company Company { get; set; }
}