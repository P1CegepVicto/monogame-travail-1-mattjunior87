using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrypteMessage
{
    class Program
    {
        static void Main(string[] args)
        {
            string motSecret;

            Console.WriteLine("entrer un mot");
            motSecret = Console.ReadLine();

            int[] tabSecret = new int[motSecret.Length];
            
            byte[] codeASCIIdeT = Encoding.ASCII.GetBytes(motSecret);
            for (int i = 0; i < tabSecret.Length; i++)
            {
                tabSecret[i] = codeASCIIdeT[i];
                Console.Write(tabSecret[i] + " ");
            }

            Console.ReadLine();
           
        }
    }
}
