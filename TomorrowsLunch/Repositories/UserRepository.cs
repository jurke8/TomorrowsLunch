using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TomorrowsLunch.Models;
using System;


namespace TomorrowsLunch.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public List<User> GetAll()
        {
            var usersList = new List<User>();
            using (var db = new ApplicationDbContext())
            {
                usersList = db.Users.ToList();
            }
            return usersList;
        }
        public User GetSpecificById(Guid specificUserId)
        {
            IQueryable<User> user;
            using (var db = new ApplicationDbContext())
            {
                user = db.Users.Where(u => u.Id == specificUserId);
            }
            return user.FirstOrDefault();
        }
        public User GetSpecificByName(string specificUserName)
        {
            User user;
            using (var db = new ApplicationDbContext())
            {
                user = db.Users.Where(u => specificUserName.Equals(u.Name)).FirstOrDefault();
            }
            return user;
        }
        public bool UserNameExist(string name)
        {
            var users = GetAll();
            var names = new List<string>();
            users.ForEach(u => names.Add(u.Name));
            return (names.Contains(name)) ? true : false;
        }
    }
}