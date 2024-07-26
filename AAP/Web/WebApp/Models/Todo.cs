namespace WebApp.Models;

public class Todo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsDone { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
