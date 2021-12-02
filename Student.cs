using System;
using System.Collections.Generic;
using System.Text;

namespace _3_praktine
{
    public class Student : IUser
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Group Group { get; set; }

        public Student() // for error's sake
        {
            Group = new Group();
        }
       
        public bool IsAdmin()
        {
            return false;
        }

        public bool IsLecturer()
        {
            return false;
        }
    }
}
