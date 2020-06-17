using System;

namespace AccessControl.BusinessRule.Models
{
    public class AuthenticatedUser
    {
        private string _name;
        private string _lastName;
        private DateTime _birthDate;
        private string _email;
        string _id;


        LoginUser _user;

        public AuthenticatedUser()
        {

        }

        public void sertUser(User user, string email)
        {
            _id = user.Id;
            _name = user.Name;
            _lastName = user.LastName;
            _birthDate = user.BirthDate;
            _email = email;
        }

        public string Id { get { return _id; } }
        public string Name { get { return _name; } }
        public string LastName { get { return _lastName; } }
        public string Email { get { return _email; } }
        public DateTime BirthDate { get { return _birthDate; } }



    }
}
