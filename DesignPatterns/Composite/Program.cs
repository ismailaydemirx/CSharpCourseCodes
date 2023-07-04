using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Employee ismail = new Employee { Name = "İsmail Aydemir" };
            Employee deniz = new Employee { Name = "Deniz Eylül" };
            Employee ege = new Employee { Name = "Ege Aydemir" };
            Employee ahmet = new Employee { Name = "Ahmet Aydemir" };

            ismail.AddSubordinate(deniz);
            ismail.AddSubordinate(ege);

            ege.AddSubordinate(ahmet);

            Contractor ali = new Contractor { Name="Ali"};

            deniz.AddSubordinate(ali);

            Console.WriteLine(ismail.Name);
            foreach (Employee manager in ismail)
            {
                Console.WriteLine("  ->{0}", manager.Name);

                foreach (IPerson employee in manager)
                {
                    Console.WriteLine("    ->{0}", employee.Name);
                }

            }

            Console.ReadLine();

        }
    }

    interface IPerson
    {
        string Name { get; set; }
    }

    class Contractor : IPerson
    {
        public string Name { get; set; }
    }

    class Employee : IPerson, IEnumerable<IPerson> // Bu nesnelere ulaşabileceğimi söylediiğim için nesneleri iterate edebileceğimiz IEnumerable 'ı ekliyoruz.
    {
        List<IPerson> _subordinates = new List<IPerson>();


        public void AddSubordinate(IPerson person)
        {
            _subordinates.Add(person);
        }

        public void RemoveSubordinate(IPerson person)
        {
            _subordinates.Remove(person);
        }

        public IPerson GetSubordinate(int index)
        {
            return _subordinates[index];
        }

        public string Name { get; set; }

        public IEnumerator<IPerson> GetEnumerator()
        {
            foreach (var subordinate in _subordinates)
            {
                yield return subordinate; // yield koleksiyondaki elemanları tek tek döndürmemizi sağlıyor.
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
