namespace Business.Models;

public class RegularUser : BaseUser
{
        public override string GetRole()
        {
            return "Regular";
        }
}