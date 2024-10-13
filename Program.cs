namespace Turn_Based_Combat_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Angreif!");
            Console.WriteLine("A Turn Based Combat Game.");
            Console.WriteLine("Enter 'a' to attack or 'h' to heal: (only a/h)");

            int plLive = 100, aiLive = 100, plAttack, aiAttack, heal, rounds = 0;
            char action;
            bool flag;
            Random random = new();


            while (plLive > 0 && aiLive > 0)
            {
                plAttack = random.Next(5,21); 
                aiAttack = random.Next(5, 21);
                heal = random.Next(5, 11);

                Console.WriteLine("============================================");
            
                
            Console.WriteLine();
            Console.WriteLine();

            // Player turn
            Console.WriteLine($"Round {rounds += 1}");
            Console.WriteLine($"Status:  [you:{plLive} | enemy:{aiLive}]");

                Console.WriteLine("--- Your turn ---");
            do
            {
                flag = char.TryParse(Console.ReadLine() ,out action);
            }while (!flag || !(action == 'a' || action == 'h'));


                if (action == 'a')
                {
                    aiLive -= plAttack;
                    Console.WriteLine($"You attacked the enemy and deals {plAttack} damage!");
                }
                else
                {
                    if ((plLive + heal) <= 100)
                    {
                        plLive += heal;
                    }
                    else
                    {
                        plLive = 100;
                    }
                    Console.WriteLine($"You restores {heal} of your live!");
                }

                Thread.Sleep(1000);
                Console.WriteLine("#####################################");

                // Enemy turn
                if (aiLive > 0)
                {
                 Console.WriteLine("--- Enemy turn ---");
                  int aiChoice = random.Next(0,2);

                    if (aiChoice == 0)
                    {
                        plLive -= aiAttack;
                        Console.WriteLine($"Enemy attacked you and deals {aiAttack} damage!");
                    }
                    else
                    {
                        if ((aiLive + heal) <= 100)
                        {
                            aiLive += heal;
                        }
                        else
                        {
                            aiLive = 100;
                        }
                        Console.WriteLine($"Enemy restores {heal} of his live!");
                    }
                }
            }


            Console.WriteLine();


            if (plLive <= 0)
            {
                Console.WriteLine("----------------------------------");
                Console.WriteLine("Unfortunately you lost!!!");
                Console.WriteLine("You were to close try again!!!");
                Console.WriteLine("----------------------------------");
            }
            else
            {
                Console.WriteLine("*********************************");
                Console.WriteLine("Congratulations you have WON!!!");
                Console.WriteLine("*********************************");
            }



            Console.ReadKey();
        }
    }
}
