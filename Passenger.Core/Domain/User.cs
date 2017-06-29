using System;

namespace Passenger.Core.Domain
{
    //
    // Summary:
    //     Klasa reprezentujaca model uzytkownika systemu 
    //
    public class User
    {
        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string UserName { get; protected set; }
        public string FullName { get; protected set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }

        protected User()
        {
        }

        public User(string email, string username, string password, string salt)
        {
            Id = Guid.NewGuid();
            SetEmail(email);
            SetUsername(username);
            SetPassword(password);
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new Exception("Username can't be empty!");
            }
            if (UserName == username)
                return;

            UserName = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email can't be empty!");
            }
            if (Email == email)
                return;

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password can't be empty!");
            }
            if (password.Length < 6)
            {
                throw new Exception("Password must contain at least 4 characters!");
            }
            if (password.Length > 20)
            {
                throw new Exception("Password can't contain more than 20 characters!");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}