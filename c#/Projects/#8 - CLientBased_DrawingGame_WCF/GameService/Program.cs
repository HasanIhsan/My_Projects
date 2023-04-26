using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;
using GamerLib;
using System.Threading;
namespace GameService
{
    internal class Program
    { 
        static void Main(string[] args)
        {

           

            ServiceHost servHost = null;
            try
            {
                // Create the service host 
                //servHost = new ServiceHost(typeof(DrawingCommand));
                servHost = new ServiceHost(typeof(DrawingService), new Uri("net.tcp://localhost:5000"));
                servHost.AddServiceEndpoint(typeof(IDrawingService), new NetTcpBinding(), "DrawingServiceEndpoint");
                // Manage the service’s life cycle
                servHost.Open();
                Console.WriteLine("Service started. Press a key to quit.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.ReadKey();
                servHost?.Close();
            }


        }
    }
}
