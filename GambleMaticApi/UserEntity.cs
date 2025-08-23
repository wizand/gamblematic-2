namespace GambleMaticApi
{
    internal class UserEntity
    {
        public string Username { get; internal set; }
        public string Email { get; internal set; }
        public string RealName { get; internal set; }
        public bool IsAdmin { get; internal set; }
    }
}