using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionBinaire
{
    class Program
    {
        static bool[] octet = new bool[8];
        static string[] motPasseInvalides = new string[3]; 

        static void Main(string[] args)
        {
            
            string motPasseUsager = "123";
            string motPasseEntree;
            string commandeUsager;
            string trueOrFalse;
            double Decimal = 0;

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("écriver votre mot de passe");
                motPasseEntree =  Console.ReadLine();

                if (motPasseUsager == motPasseEntree)
                {
                    Console.WriteLine("1 : Lire un octet");
                    Console.WriteLine("2 : Afficher un octet");
                    Console.WriteLine("3 : Traduire l’octet en décimal");
                    Console.WriteLine("4 : Quitter");
                    Console.WriteLine();
                    Console.WriteLine("entré votre commande");
                    commandeUsager = Console.ReadLine();

                    switch (commandeUsager)
                    {
                        case "1":
                            for (int a = 0; a < 8; a++)
                            {
                                Console.WriteLine("t (true) pour 1");
                                Console.WriteLine("f (false) pour 0");
                                Console.WriteLine("Entrer vaut bit " + a);
                                trueOrFalse = Console.ReadLine();
                                trueOrFalse = trueOrFalse.ToLower();

                                if (trueOrFalse == "t")
                                {
                                    octet[a] = true;
                                }
                                else if (trueOrFalse == "f")
                                {
                                    octet[a] = false;
                                }
                    


                            }

                            break;

                        case "2":
                            for (int a = 0; a < 8; a++)
                            {
                                  
                                if (octet[a] == true)
                                {
                                    Console.Write("1");

                                }
                                if (octet[a] == false)
                                {
                                    Console.Write("0");
                                }
                                if (a == 3)
                                {
                                    Console.Write(" ");
                                }
                            }
                            Console.ReadLine();
                            break;

                        case "3":
                            for (int a = 0; a < 8; a++)
                            {
                                if (octet[a] == true)
                                {
                                    Decimal = Decimal + Math.Pow(a, 2);

                                }
                                if (octet[a] == false)
                                {
                                    Decimal = Decimal + 0;
                                }

                            }
                            Console.WriteLine("Réponse : " + Decimal);
                            Console.ReadLine();
                            break;

                        case "4":
                            System.Environment.Exit(1);
                            break;
                    }



                }
                
                else
                {
                    motPasseInvalides[i] = motPasseEntree;
                }

            }
            Console.WriteLine("erreur, mot de passe incorrect, shutdown system");
            Console.Write(motPasseInvalides[0]);
            Console.Write("   ");
            Console.Write(motPasseInvalides[1]);
            Console.Write("   ");
            Console.Write(motPasseInvalides[2]);


            Console.ReadLine();
            System.Environment.Exit(1);

        }
    }
}
