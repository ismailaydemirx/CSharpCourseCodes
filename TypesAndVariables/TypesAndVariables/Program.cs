using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypesAndVariables
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Value Types
            double number1 = 10000000000;
            short number2 = -32768;
            decimal number3 = 10.3342342m;
            Console.WriteLine((int)days.Thursday);

            var number7 = 11;
            
            Console.WriteLine("Number1 is : {0}" ,number1);
            Console.WriteLine("Number3 is : {0}" ,number3);
            Console.ReadLine();
        }
    }

    enum days
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
}
