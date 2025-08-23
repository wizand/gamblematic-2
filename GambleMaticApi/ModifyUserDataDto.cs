namespace GambleMaticApi
{
    public class ModifyUserDataDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public bool IsAdmin { get; set; }
    }
}
