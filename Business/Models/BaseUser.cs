namespace Business.Models;

public abstract class BaseUser
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public abstract string GetRole();
}