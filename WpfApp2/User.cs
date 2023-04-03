using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Hobby { get; set; }

        public User()
        {
            Email = string.Empty;
            Password = string.Empty;
        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public User(string email, string password, string hobby)
        {
            Email = email;
            Password = password;
            Hobby = hobby;
        }

        public override bool Equals(object? obj)
        {
            if(ReferenceEquals(null, obj)) 
                return false;
            if(ReferenceEquals(this, obj))
                return true;
            if(obj.GetType() != GetType())
                return false;
            var user = (User)obj;
            return Email == user.Email
                && Password == user.Password
                && Hobby == user.Hobby;
        }

        public static bool operator ==(User a, User b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(User a, User b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            var hash = Email.GetHashCode() ^ Password.GetHashCode();
            if(Hobby != null)
                hash ^= Hobby.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            var str = $"Email: {Email}";
            if (Hobby == null)
                str += $"\nHobby: {Hobby}";
            return str;
        }
    }
}
