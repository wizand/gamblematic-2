using System.ComponentModel.DataAnnotations;

namespace GambleMaticApi.DatabaseEntities
{
    public class UserEntity : BaseEntity 
    {
        
        public string Username { get; set; }
        public string Email { get; set; }
        public string RealName { get; set; }
        public bool IsAdmin { get; set; }

        public const string TABLE_NAME = "Users";
        public const string INSER_SQL = $"INSERT INTO {TABLE_NAME} (Username, Email, RealName, IsAdmin, IDate, UDate) VALUES (@Username, @Email, @RealName, @IsAdmin, @IDate, @UDate);";
        public const string UPDATE_SQL = $"UPDATE {TABLE_NAME} SET Username = @Username, Email = @Email, RealName = @RealName, IsAdmin = @IsAdmin, UDate = @UDate WHERE Id = @Id;";
    }
}