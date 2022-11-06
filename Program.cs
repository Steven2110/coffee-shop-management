using System;

namespace CoffeeShopManagementApp {

    class Program {
        static void Main() {
            List<Person> population = generatePopulation(12);
            
            CoffeeShop myCoffeeShop = new CoffeeShop();
            
            List<Person> candidates = new List<Person>();
            for(int i = 0; i < 6; i++) {
                Random random = new Random();
                candidates.Add(population[i]);
            }
            Console.WriteLine("Hiring employee");
            foreach(Person candidate in candidates) {
                myCoffeeShop.hireEmployee(candidate);
            }

            Console.WriteLine("Show all employee");
            myCoffeeShop.getEmployees();
            Console.WriteLine("Creating menu");
            myCoffeeShop.managers[0].makeMenu();

            Person customer = population[7];
            Cashier cashier = myCoffeeShop.cashiers[0];
            Console.WriteLine("Registering customer");
            cashier.registerCustomer(customer);
            Console.WriteLine("Making order");
            if (myCoffeeShop.customers[0].makeOrder(cashier)) {
                Console.WriteLine("Your order have sucessfully placed.");
            } else {
                Console.WriteLine("Your order can't be placed.");
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