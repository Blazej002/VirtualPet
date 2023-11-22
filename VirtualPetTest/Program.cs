namespace VirtualPetTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pet = new Pet("Gucio");

            Console.WriteLine("Your pet");
            Console.WriteLine("Name : {0}, hunger : {1}, happiness : {2}", pet.Name, pet.hunger, pet.happiness);
            Console.WriteLine("Hvilket dyr vil du ta vare på ?");
            while (true)
            {
                Ask(pet);
                var userInp = Console.ReadLine();
                switch (userInp)
                {
                    case "1":
                        pet.feed();
                        break;
                    case "2":
                        pet.play();
                        break;
                    case "3":
                        pet.doBathroomCheck();
                        break;
                }

                Thread.Sleep(1200);
                Console.Clear();
            }
        }

        private static void Ask(Pet pet)
        {
            Console.WriteLine(pet.Name);
            Console.WriteLine("1. Gi {0} mat", pet.Name);
            Console.WriteLine("2. Kos med {0}", pet.Name);
            Console.WriteLine("3. Sjekk om {0} må på do", pet.Name);
            Console.WriteLine();
        }
    }

    class Pet
    {
        public String Name { get; private set; }
        public int hunger { get; private set; }
        public int happiness { get; private set; }
        public bool wantToGoOut { get; private set; }

        public Pet(string name = "Picachu")
        {
            Name = name;
            hunger = 50;
            happiness = 50;
            wantToGoOut = false;
        }

        public void feed()
        {
            Console.WriteLine($"{Name} er mett og fornøyd");
            hunger -= 10;
            Random random = new Random();
            int ran = random.Next(0, 1);
            if (ran == 1)
            {
                wantToGoOut = true;
            }
        }

        public void play()
        {
            Console.WriteLine($"{Name} smiler");
            happiness += 10;
        }

        public void doBathroomCheck()
        {
            Console.WriteLine($"Sjekker om {Name} må på do.");
            checkBathroom();

            if (wantToGoOut)
            {
                Console.WriteLine($"{Name} må på do.");
                Console.WriteLine("Går du utt med han?");
                Console.WriteLine("y/n");
                var YesNo = Console.ReadLine();
                if (YesNo.ToLower() == "y")
                {
                    hunger += 5;
                    wantToGoOut = false;
                    Console.WriteLine("{0} ser glad", Name);
                }
                else
                {
                    happiness--;
                    wantToGoOut = true;
                    Console.WriteLine("{0} Is unhappy by your choice", Name);
                }
            }
            else
            {
                Console.WriteLine($"{Name} må ikke på do.");
            }
        }

        public void checkBathroom()
        {
            wantToGoOut = false;

            if (hunger < 40)
            {
                wantToGoOut = true;
            }
        }
    }
}