using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using poptwit.Models;

namespace poptwit.Repos
{
    public class UserRepo
    {
        private string GetUID(HttpRequest request)
        {
            return request.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public User GetOrCreate(PopContext db, HttpRequest request)
        {
            string uid = GetUID(request);

            User user = db.Users
                .SingleOrDefault(s => s.UID == uid);
            
            if (user == null)
            {
                user = new User()
                {
                    UID = uid,
                };
                db.Users.Add(user);
                db.SaveChanges();
            }

            return user;
        }
    }
}