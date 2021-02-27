﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactCRUD.services
{
    public class UserService
    {
        private static List<User> users = new List<User>();
        private static int Count = 1;
        private static readonly string[] names = new string[] { "Jonathan", "Mary", "Susan", "Joe", "Paul", "Carl", "Amanda", "Neil" };
        private static readonly string[] surnames = new string[] { "Smith", "O'Neil", "MacDonald", "Gay", "Bailee", "Saigan", "Strip", "Spenser" };
        private static readonly string[] extensions = new string[] { "@gmail.com", "@hotmail.com", "@outlook.com", "@icloud.com", "@yahoo.com" };
        static UserService()
        {
            Random rnd = new Random();
            for(int i = 0; i < 5; i++)
            {
                string currName = names[rnd.Next(names.Length)];
                User user = new User
                {
                    Id = Count++,
                    Name = currName + " " + surnames[rnd.Next(surnames.Length)],
                    Email = currName.ToLower() + extensions[rnd.Next(extensions.Length)],
                    Document = (rnd.Next(1, 100000) * rnd.Next(0, 100000)).ToString().PadLeft(10, '0'),
                    Phone = "+1 888-452-1232"
                };
                users.Add(user);
            }
        }
        public List<User> GetAll()
        {
            return users;
        }
        public User GetById(int id)
        {
            return users.Where(user => user.Id == id).FirstOrDefault();
        }

    }
}
