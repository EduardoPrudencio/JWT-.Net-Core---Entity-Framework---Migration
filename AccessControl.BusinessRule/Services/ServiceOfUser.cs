using AccessControl.BusinessRule.Models;
using AccessControl.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;

namespace AccessControl.BusinessRule.Services
{
    public class ServiceOfUser
    {
        List<User> _user;

        private readonly IUserRepository _userRepository;


        public ServiceOfUser(IUserRepository _userRepository)
        {
            _user = new List<User>();
        }

        public List<User> GetPeople()
        {
            return new List<User>
            {
                new User{Name = "Pedro", LastName ="Silva",  BirthDate = new DateTime(1983,9,2) },
                new User{Name = "Jorge", LastName ="Aguiar", BirthDate = new DateTime(1980,6,7) },
                new User{Name = "João" , LastName ="Moura",  BirthDate = new DateTime(1994,8,12) },
            };
        }

        //private void Insert(User user)
        //{
        //    try
        //    {
        //        using (var context = new AccessContext())
        //        {

        //            context.User.Add(user);
        //            context.SaveChanges();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

    }
}
