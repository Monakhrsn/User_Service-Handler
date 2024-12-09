namespace Business.Models;

public class AdminUser : BaseUser
{
    public override string GetRole()
    {
        return "Admin";
    }
}
