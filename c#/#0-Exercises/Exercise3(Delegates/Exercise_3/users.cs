namespace Exercise_3
{
    public class users
    {
        public string loginname = "";
        public string password = "";
        public string roles = "";

        public int NoOFTransactions = 0;

        public  users()
        {

        }

        public users(string loginname, string password, string roles)
        {
            this.loginname = loginname;
            this.password = password;
            this.roles = roles;
        }
    }
}