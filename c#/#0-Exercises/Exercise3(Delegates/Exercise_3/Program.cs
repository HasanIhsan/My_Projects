namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<users> newuser = new();

            newuser.Add( new users("hiro", "pass", "Guest"));
            newuser.Add(new users("yuki", "pass2", "Admin"));
            newuser.Add(new users("saya", "pass3", "Trusted"));

            security n = new();

            n.InsertUsers(newuser);

            users n1 = new users("hiro", "pass2", "Guest2");
            users n2 = new users("yuki", "pass2", "Admin");
            users n3 = new users("saya", "pass3", "Trusted");


            //n.setUser(n1);


            Action<users> analyticsHandler = n.setUser;

            analyticsHandler += n.authentication;
            analyticsHandler += n.authorization;

            analyticsHandler.Invoke(n1);
            Console.WriteLine();
            analyticsHandler.Invoke(n2);

            Console.WriteLine();
            analyticsHandler.Invoke(n3);
        }
    }
}