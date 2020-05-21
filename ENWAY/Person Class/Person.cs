using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENWAY
{
    abstract class Person
    {
        private string _Name;
        private string _Surname;
        private int _Tc;
        private string _Email;
        private int _Phone;


        public string Name { get => _Name; set => _Name = value; }
        public string Surname { get => _Surname; set => _Surname = value; }
        public int Tc { get => _Tc; set => _Tc = value; }
        public string Email { get => _Email; set => _Email = value; }
        public int Phone { get => _Phone; set => _Phone = value; }
    }
}