using System;

namespace CoffeeShopManagementApp {

    class Program {
        static void Main() {
            List<Person> population = generatePopulation(12);
            
            CoffeeShop myCoffeeShop = new CoffeeShop();
            
            List<Person> candidates = new List<Person>();
            for(int i = 0; i < 6; i++) {
                Random random = new Random();
                candidates.Add(population[random.Next(12)]);
            }
            
            foreach(Person candidate in candidates) {
                myCoffeeShop.hireEmployee(candidate);
            }

            
        }

        static List<Person> generatePopulation(int numberOfPeople) {
            List<Person> population = new List<Person>();
            for(int i = 0; i < numberOfPeople/2; i++) {
                string name = "John Doe " + (i + 1).ToString();
                string email = "johndoe" + (i + 1).ToString() + "@test.com";
                string phone = "12345" + (i + 1).ToString();
                Person newPerson = new Person(name, email, phone);
                population.Add(newPerson);
            }
            for(int i = numberOfPeople/2; i < numberOfPeople; i++) {
                string name = "Alan Adolf " + (i + 1).ToString();
                string email = "alanadlf" + (i + 1).ToString() + "@test.com";
                string phone = "78945" + (i + 1).ToString();
                Person newPerson = new Person(name, email, phone);
                population.Add(newPerson);
            }
            return population;
        }
    }
}