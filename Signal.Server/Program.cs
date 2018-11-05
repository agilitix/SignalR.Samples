using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Signal.Server
{
    static class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:5000/";

            using (Server server = new Server())
            {
                server.Start(baseAddress);

                Console.WriteLine();
                Console.Write("Press enter to exit:");
                Console.ReadLine();
            }
        }
    }
}
