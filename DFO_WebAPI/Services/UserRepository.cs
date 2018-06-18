using DFO_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DFO_WebAPI.Services
{
    public class UserRepository
    {
        private const string CacheKey = "UserStore";

        public UserRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var contacts = new List<UserModel>
                    {
                        new UserModel
                        {
                            Id = 1, Name = "User 1", Age = 20, Address = "Abc Street"
                        },
                        new UserModel
                        {
                            Id = 2, Name = "User 2", Age = 30
                        }
                    };
                    ctx.Cache[CacheKey] = contacts;
                }
            }
        }

        public List<UserModel> GetAllUsers()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (List<UserModel>)ctx.Cache[CacheKey];
            }

            return new List<UserModel>
            {
                new UserModel
                {
                    Id = 0,
                    Name = "Default",
                    Age = 0
                }
            };
        }

        public UserModel GetUserById(int id)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return ((List<UserModel>)ctx.Cache[CacheKey]).FirstOrDefault(u => u.Id == id);
            }

            return new UserModel
            {
                Id = 0,
                Name = "Default",
                Age = 0
            };
        }

        public bool CreateUser(UserModel user)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = (List<UserModel>)ctx.Cache[CacheKey];
                    user.Id = currentData.Last().Id + 1;
                    currentData.Add(user);
                    ctx.Cache[CacheKey] = currentData;

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }

        public bool UpdateUser(UserModel user)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = (List<UserModel>)ctx.Cache[CacheKey];
                    int index = currentData.FindIndex(u => u.Id == user.Id);
                    currentData[index].Name = user.Name;
                    currentData[index].Age = user.Age;
                    currentData[index].Address = user.Address;
                    ctx.Cache[CacheKey] = currentData;

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}