using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritence
{
    class Person
    {
        protected string firstName, lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine("First name: " + firstName);
            Console.WriteLine("Last name: " + lastName + "\n");
        }

        static void Main()
        {
            Person person1 = new Person("Ian", "Mutch");
            person1.PrintInfo();

            Student student1 = new Student("Gary", "Mutch", 1306986, "Forensic Science");
            student1.PrintInfo();
            student1.Learn();

            Person person2 = new Student("John", "Diggle", 123456, "Fighter");
            Student student2 = (Student)person2;
            student2.PrintInfo();
            student2.Learn();

            Console.ReadLine();
        }
    }
}
