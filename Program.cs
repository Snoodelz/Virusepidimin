using System;
using System.Collections.Generic;
using System.Linq;

namespace Virusepidimin
{
    class Program
    {
        static List<Person> diskotek = new List<Person>();

        static void Main(string[] args)
        {
            AddPeople(50);
            while (true)
            {
                int amount = 0;
                int infected = 0;
                int immune = 0;
                foreach (var person in diskotek)
                {
                    amount++;
                    if (person.HoursInfected >= 5)
                    {
                        person.Immune = true;
                        person.Infected = false;
                    }

                    if (person.Infected)
                    {
                        infected++;
                        person.HoursInfected++;
                    }
                        
                    if (person.Immune)
                        immune++;
                }
                Console.WriteLine($"Infekterade: {infected}, immuna: {immune}");

                bool spreadVirus = false;
                while (!spreadVirus)
                {
                    Random random = new Random();
                    int number = random.Next(0, diskotek.Count);
                    if(infected <= 0)
                    {
                        spreadVirus = true;
                    }
                    else if (!diskotek[number].Infected | !diskotek[number].Immune)
                    {
                        diskotek[number].Infected = true;
                        infected--;
                    }
                }
                Console.ReadLine();

            }

        }

        private static void AddPeople(int amount)
        {
            for (int i = 0; i < 50; i++)
            {
                if (i == 0)
                    diskotek.Add(new Person(true, 0));
                else
                    diskotek.Add(new Person(false));
            }
        }
    }

    class Person
    {
        public bool Infected { get; set; }
        public int HoursInfected { get; set; }
        public bool Immune { get; set; }

        public Person(bool infected, int hoursInfected = 0, bool immune = false)
        {
            Infected = infected;
            HoursInfected = hoursInfected;
            Immune = immune;
        }
    }
}
