namespace Business.Models;

public class Projects
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }


    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

}
