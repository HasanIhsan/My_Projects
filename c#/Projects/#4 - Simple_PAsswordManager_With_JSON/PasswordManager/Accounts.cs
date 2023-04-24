/*
 * Program:        
 * Module:         Accounts.cs
 * Date:            00-00-0000
 * Author:          <hassan Ihsan>
 * Description:    the Account class and password class to contain the values that are needed
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PasswordManager
{
    [DataContract]
    class password
    {
        [DataMember(IsRequired = true)]
        public string value { get; set; }
        [DataMember(IsRequired = true)]
        public int strennum { get; set; }
        [DataMember(IsRequired = true)]
        public string strentext { get; set; }
        [DataMember(IsRequired = false)]
        public string lastreset { get; set; }
    }

    [DataContract]
    class Accounts
    {
        [DataMember]
        public int accountId { get; set; }
        [DataMember(IsRequired = true)]
        public string Description { get; set; }
        [DataMember(IsRequired = true)]
        public string userId { get; set; }
        [DataMember(IsRequired = false)]
        public string loginURL { get; set; }
        [DataMember(IsRequired = false)]
        public string accountnum { get; set; }
        [DataMember(IsRequired = true)]
        public List<password> password = new List<password>();
        public void AddItem(password item)
        {
            password.Add(item);
        }



    }
 
}
