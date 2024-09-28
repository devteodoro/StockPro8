using StockPro.Domain.Enums;
using System.Text.Json.Serialization;

namespace StockPro.Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = string.Empty;

        public string Login { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        [JsonIgnore]
        public string PasswordHash { get; set; } = string.Empty;

        public Profile Profile { get; set; }

        public UserPreference? Preference { get; set; }

        public ICollection<ServiceRequest>? ServiceRequests { get; set; }

        public User() { }

        public User(string name, string login, string email, string passwordHash, Profile profile)
        {
            Name = name;
            Login = login;
            Email = email;
            PasswordHash = passwordHash;
            Profile = profile;
        }

        public User(string name, string login, string email, string passwordHash, Profile profile, UserPreference preference)
        {
            Name = name;
            Login = login;
            Email = email;
            PasswordHash = passwordHash;
            Profile = profile;
            Preference = preference;
        }

        public void setPreference(Theme theme)
        {
            if (Preference == null)
                Preference = new UserPreference(theme);
            else
                Preference.Theme = theme;
        }
    }
}
