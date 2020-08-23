using ClimbingApp.Models;

using Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace WebApi.Services
{


    public interface IUserService
    {
        User Authenticate(string id);
        void Logout();
    }

    public class UserService : IUserService
    {

        private readonly ClimbAppContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private String UserIDSess => _httpContextAccessor.HttpContext.Session.GetString("oic");

        public UserService(ClimbAppContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // Add a user upon new signup and add a sesssion
        public User Authenticate(string id)
        {


            var user = _context.Users.Find(id);


            if (user == null)
            {


                User userNew = new User
                {
                    UserID = id
                };

                Stat stat = new Stat
                {
                    UserID = id
                };


                _context.Users.Add(userNew);

                _context.Stats.Add(stat);

                _context.SaveChangesAsync();
            }

            if (UserIDSess != id)
            {
                _httpContextAccessor.HttpContext.Session.SetString("oic", id);
            }

            // authentication successful
            return null;
        }

        public void Logout()
        {
            Debug.WriteLine("Logout call");
            _httpContextAccessor.HttpContext.Session.Clear();

        }
    }
}