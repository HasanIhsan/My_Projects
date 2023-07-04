//Programmer: Hassan Ihsan
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    internal class Student
    {
        string firstname;
        string lastname;
        string emailAddress;

        public Student (string firstname, string lastname, string emailAddress)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.emailAddress = emailAddress;
        }

        public override string ToString()
        {
            return firstname+ " " + lastname + " " +emailAddress;
        }
    }
}
