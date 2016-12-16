using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateProj
{
    class Delegato
    {
        delegate int BRO(int x);

        static void Main()
        {
            int temp = 5;
            BRO bro1 = new BRO(AddUP);
            bro1 += (MinDown);
            bro1 += (TimesUP);
            bro1 += (DivideDOWN);

            temp = bro1(temp);
            Console.ReadLine();
        }

        static int AddUP(int val)
        {
            val += 2;
            Console.WriteLine(val);
            return val;
        }
        static int MinDown(int val)
        {
            val -= 2;
            Console.WriteLine(val);
            return val;
        }
        static int TimesUP(int val)
        {
            val *= 2;
            Console.WriteLine(val);
            return val;
        }
        static int DivideDOWN(int val)
        {
            val /= 2;
            Console.WriteLine(val);
            return val;
        }

    }
}
