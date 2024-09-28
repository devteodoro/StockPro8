using StockPro.Domain.Enums;

namespace StockPro.Domain.Models
{
    public class UserPreference : BaseEntity
    {
        public Theme Theme { get; set; }

        public int UserId { get; set; }

        public User User { get; set; } = new();

        public UserPreference()
        {
        }

        public UserPreference(Theme theme)
        {
            Theme = theme;
        }

        public UserPreference(Theme theme, User user)
        {
            Theme = theme;
            User = user;
            UserId = user.Id;
        }
    }
}
