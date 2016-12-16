using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence
{
    class Teacher : Person
    {
        private int staffID;
        private string subject;

        public Teacher(string firstName, string lastName, int staffID, string subject) : base(firstName, lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public void StartLesson()
        {
            Console.WriteLine("The Lesson has started");
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine("Staff ID: " + staffID);
            Console.WriteLine("subject: " + subject);
        }
    }
}
