using GUI;

namespace Project1
{
    public class ProgramManagement
    {
        public const string help = "-h";

        public const string display = "-d";

        //public string[] commands = [help, display];

        public void ResetConsole()
        {
            Console.Clear();
            GUI.GUI.MakeTitle();
        }
        
        public void HandleArgs(string[] args)
        {
            switch(args[1])
            {
                case help:
                    Help();
                    break;
            }
        }

        private void Help()
        {
            /*
            
             */
        }
    }
}
