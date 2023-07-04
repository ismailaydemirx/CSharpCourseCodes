using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Classes
{
    class Customer
    {
        //field (alan)
        // public string FirstName;

        // Property (özellik)
        private int _Id;
        public int Id
        {
            get
            { return _Id; }
            set
            { _Id = value; }
        }
        private string _FirstName;
        public string FirstName 
        {
            get { return "Mr." + _FirstName; }

            set { _FirstName = value; }
        
        }
        public string LastName { get; set; }
        public string City { get; set; }

    }
}
