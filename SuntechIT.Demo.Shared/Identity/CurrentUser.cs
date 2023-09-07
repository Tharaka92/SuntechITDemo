namespace SuntechIT.Demo.Shared.Identity
{
    public class CurrentUser
    {
        public string? Id { get; set; }

        public string? Email { get; set; }

        public string? Role { get; set; }

        public bool IsAdmin
        {
            get
            {
                return Role != null && Role == "Admin";
            }
        }

        public bool IsSuperAdmin
        {
            get
            {
                return Role != null && Role == "SuperAdmin";
            }
        }

        public bool IsNormalUser
        {
            get
            {
                return Role != null && Role == "Normal";
            }
        }
    }
}
