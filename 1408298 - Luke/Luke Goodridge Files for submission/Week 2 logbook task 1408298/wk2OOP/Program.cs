using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wk2OOP
{
    class Program
    {
        static void Main()
        {
            int studentID = 1437265;
            string firstName = "Jordan", surName = "Hooper", course = "CGT (extended)";

            Student firstStudent = new Student();
            Student secondStudent = new Student(studentID, firstName, surName, course);

            firstStudent.DisplayData();
            Console.WriteLine();
            secondStudent.DisplayData();
            Console.ReadLine();

        }
    }
}
