namespace Exercise_3
{
    public class security
    {
        private List<users> _regusteredUsers = new();
        users _testedUser;

        public void InsertUsers(List<users> newuser)
        {
            _regusteredUsers.AddRange(newuser);
        }

        public void setUser(users currentuser)
        {
            _testedUser = currentuser;
        }

        public void authentication(users use )
        {

          
            foreach(users user in _regusteredUsers)
            {
                if (_testedUser.loginname == user.loginname && _testedUser.password == user.password)
                {
                    Console.WriteLine("Login Sucessful!");
                     
                }
                else if(_testedUser.loginname == "")
                {
                    Console.WriteLine("Login Failed - User Login is Empty ");
                  
                }else
                {
                    Console.WriteLine("login Failed - Password or login name is incorrect");
                   
                }

               
            }

           
        }

        public void authorization(users use)
        { 
            if(_testedUser.roles == "Admin")
            {
                Console.WriteLine("Admin: All Privileages are granted");

            }else if (_testedUser.roles == "Trusted")
            {
                Console.WriteLine("Trusted: Read/Write Privileages are granted!");
            }
            else if(_testedUser.roles == "Guest")
            {
                Console.WriteLine("Guest: Read Privileages are only granted!");
            }
            else
            {
                Console.WriteLine($"No Privileages have assigned to this user (Admin, Trusted, Guest) for {_testedUser.loginname}");
            }
        }
    }
}