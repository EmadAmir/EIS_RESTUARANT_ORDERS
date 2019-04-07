using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace RestaurantServiceHost
{
    class Program
    {
        static void Main()
        {
            using (ServiceHost host = new ServiceHost(typeof(RestaurantService.RestaurantService)))
            {
                host.Open();
                Console.WriteLine("Host has started @ " + DateTime.Now.ToString());
                Console.ReadLine();
            }
        }
    }
}
