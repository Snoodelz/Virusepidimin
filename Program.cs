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
            int people = 50;
            int hoursInfected = 5;
            StartEpidemic(people, hoursInfected);
            
            

        }

        private static void StartEpidemic(int amount, int hoursInfected)
        {
            AddPeople(amount);
            while (true)
            {
                int infected = 0;
                int immune = 0;
                foreach (var person in diskotek)
                {
                    if (person.HoursInfected >= hoursInfected)
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

                infectPeople(infected);
            }

        }

        private static void infectPeople(int infected)
        {
            var healthyPeople = diskotek.Where(x => !x.Infected).ToList();
            for (int i = 0; i < infected; i++)
            {
                if (i < healthyPeople.Count)
                    healthyPeople[i].Infected = true;
            }
            Console.ReadLine();
        }

        private static void AddPeople(int amount)
        {
            for (int i = 0; i < amount; i++)
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
