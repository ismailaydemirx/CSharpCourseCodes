using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            VicePresident vicePresident = new VicePresident();
            President president = new President();

            manager.SetSuccessor(vicePresident);// Successor metodlarını kullanıyoruz. burada manager'ın üst sınıfı olarak VicePresident i belirledik.
            vicePresident.SetSuccessor(president); // VicePresident'in üst sınıfı olarak President'i belirledik.

            //Harcama tanımlayalım
            Expense expense = new Expense
            {
                Detail = "Training",
                Amount = 100,
            };

            manager.HandleExpense(expense);

            Console.ReadLine();
        }
    }

    class Expense
    {
        public string Detail { get; set; }
        public decimal Amount { get; set; }
    }

    abstract class ExpenseHandlerBase
    {
        protected ExpenseHandlerBase Successor; // Protected olunca inherit edildiği sınıfta kullanılabilir.
        public abstract void HandleExpense(Expense expense); // bizim senaryomuzda herkesin harcamaya yetki verme işlemleri farklı olduğu için soyut olarak tanımladık o kişiler kendisi implemente edecek.

        public void SetSuccessor(ExpenseHandlerBase successor)
        {
            Successor = successor;
        }
    }

    class Manager : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount <= 100) // 100 tlden küçük ve eşit harcamalar için bu bloğa girecek.
            {
                Console.WriteLine("Manager handled the expense!");
            }
            else if (Successor != null) // 100 tl den büyük harcamalar için buradaki kontrol sağlanacak.
                //Manager'in üst sınıfı boş değilse alt blok çalışacak.
            {
                Successor.HandleExpense(expense); // Manager'in üst sınıfı olan VicePresident'in HandleExpense metodu çalışacak.
            }

        }
    }

    class VicePresident : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 100 && expense.Amount<=1000)
            {
                Console.WriteLine("Vice President handled the expense!");
            }
            else if (Successor != null) 
            {
                Successor.HandleExpense(expense);
            }
        }
    }

    class President : ExpenseHandlerBase
    {
        public override void HandleExpense(Expense expense)
        {
            if (expense.Amount > 1000)
            {
                Console.WriteLine("President handled the expense!");
            }
        }
    }

}
