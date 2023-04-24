//Programmer: Hassan Ihsan
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    internal class Professor
    {
        string firstname;
        string lastname;
        string email;
        DateTime hiringDate;

        public Professor(string firstname, string lastname, string email, DateTime hiring)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.hiringDate = hiring;
        }

        public override string ToString()
        {
            return firstname +" " + lastname +" " + email + " " +hiringDate;
        }

    }
}
