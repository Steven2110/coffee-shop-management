public class Person {
    string name;
    int age;
    string email;
    string phone;
#nullable enable
    string? creditCardNumber;

    public string Name {
        get {
            return name;
        }
        set {
            name = value;
        }
    }

    public string Email {
        get {
            return email;
        }
        set {
            email = value;
        }
    }

    public string Phone {
        get {
            return phone;
        }
        set {
            phone = value;
        }
    }

    public Person(string name, string email, string phone) {
        Name = name;
        Email = email;
        Phone = phone;
        Random random = new Random();
        age = random.Next(70);
        if (age >= 18) {
            creditCardNumber = generateCreditCardNumber();
        } else {
            creditCardNumber = null;
        }
    }

    private string generateCreditCardNumber() {
        string creditCardNumber = "";
        for (int i = 0; i < 16; i++) {
            Random random = new Random();
            int digit = random.Next(10);
            creditCardNumber += digit.ToString();
        }

        return creditCardNumber;
    }

    public string CreditCardNumber {
        get {
            return creditCardNumber == null ? default(string) : creditCardNumber;
        }
    }

    public bool hasCreditCard() {
        if (creditCardNumber != null) {
            return true;
        } else {
            return false;
        }
    }
}

public abstract class Employee: Person {
    Guid employeeId;
    double salary;
    string dateJoined;

    public Employee(double salary, string name, string email, string phone): base(name, email, phone){
        employeeId = Guid.NewGuid();
        this.salary = salary;
        this.dateJoined = DateTime.Now.ToString("dd.MM.yy");        
    }

    public string DateJoined {
        get {
            return dateJoined;
        }
    }

    public double Salary {
        get {
            return salary;
        }
    }

    public abstract bool resign();
    public abstract void registerCustomer(Person person);
}

class Manager: Employee {
    CoffeeShop placeWork;

    public Manager(double salary, string name, string email, string phone, CoffeeShop placeWork): base(salary, name, email, phone) {
        this.placeWork = placeWork;
    }

    public bool trainBarista(Barista newBarista) {
        Random random = new Random();
        int duration = random.Next(5);
        Console.WriteLine($"Training {newBarista.Name} for {duration} days.");
        for (int i = 1; i <= duration; i++) {
            Console.WriteLine($"Day {i}: Training {newBarista.Name}.");
        }
        Console.WriteLine($"Barista {newBarista.Name} is ready to serve!");
        return true;
    }

    public override bool resign() {
        Random random = new Random();
        if (random.Next(1, 100) % 2 == 0) {
            return false;
        }
        return true;
    }
    public override void registerCustomer(Person person) {
        Customer newCustomer = new Customer(person.Name, person.Email, person.Phone, placeWork);
        // coffeeShop.registerNewCustomer(newCustomer);
        Console.WriteLine("Sucessfully added new customer");
    }

    public bool makeMenu() {
        placeWork.MENU = new Menu();
        EspressoBased espresso = new EspressoBased("Doppio", 50, 12, DrinkType.Hot, 30);
        FilterCoffee filterCoffee = new FilterCoffee("V60", 330, 33, DrinkType.Hot, 30);
        MilkCoffee latte = new MilkCoffee("Latte", 300, 30, DrinkType.Hot, 15);
        placeWork.MENU.addEspressoBased(espresso);
        placeWork.MENU.addFilterCoffee(filterCoffee);
        placeWork.MENU.addMilkBased(latte);
        return true;
    }
}

class Cashier: Employee {
    CoffeeShop placeWork;
    List<Order> todaysOrder = new List<Order>();
    public Cashier(double salary, string name, string email, string phone, CoffeeShop placeWork): base(salary, name, email, phone) {
        this.placeWork = placeWork;
    }

    public Order createOrder(Customer customer, List<Beverage> beverages) {
        Order newOrder = new Order(customer);
        foreach(Beverage beverage in beverages) {
            newOrder.addBeverage(beverage);
        }
        return newOrder;
    }

    public void registerMembership(int customerId) {

    }

    public override bool resign() {
        Random random = new Random();
        if (random.Next(1, 100) % 2 == 0) {
            return false;
        }
        return true;
    }
    public override void registerCustomer(Person person) {
        Customer newCustomer = new Customer(person.Name, person.Email, person.Phone, placeWork);
        placeWork.registerNewCustomer(newCustomer);
        Console.WriteLine("Succesfully added new customer!");
    }
}

class Barista: Employee {
    CoffeeShop placeWork;
    public Barista(double salary, string name, string email, string phone, CoffeeShop placeWork): base(salary, name, email, phone) {
        this.placeWork = placeWork;
    }
    public bool makeBeverage(Order order) {
        foreach(Beverage beverage in order.Beverages) {
            beverage.brew();
        }
        return true;
    }

    public override bool resign() {
        if (new Random().Next(1, 100) % 2 == 0) {
            return false;
        }
        return true;
    }
    public override void registerCustomer(Person person) {
        Customer newCustomer = new Customer(person.Name, person.Email, person.Phone, placeWork);
        // coffeeShop.registerNewCustomer(newCustomer);
    }
}

class Customer: Person {
    Guid customerID;
    bool hasMembership;

#nullable enable
    MembershipLevel? membershipLevel = null;

    int membershipCoffeePts;
    CoffeeShop myCoffeeShop;

#nullable enable
    string? membershipDateCreated = null;

    // List<Order> orders;

    public Customer(string name, string email, string phone, CoffeeShop coffeeShop): base(name, email, phone) {
        customerID = Guid.NewGuid();
        hasMembership = false;
        membershipCoffeePts = 0;
        myCoffeeShop = coffeeShop;
    }

    public bool buyMembership() {
        return false;
    }

    public bool makeOrder(Cashier cashier) {
        Random random = new Random();
        Menu menu = myCoffeeShop.MENU;

        List<Beverage> beveragesThatCustomerWant = new List<Beverage>();
        int numberOfBeverage = random.Next(10);
        for (int i = 0; i < numberOfBeverage; i++) {
            int randomBeverage = random.Next(menu.Beverages.Count);
            beveragesThatCustomerWant.Add(menu.Beverages[randomBeverage]);
        }
        
        Order thisOrder = cashier.createOrder(this, beveragesThatCustomerWant);
        PaymentMethod method;
        
        if (hasCreditCard()) {
            method = PaymentMethod.CreditCard;
        } else {
            method = PaymentMethod.Cash;
        }
        
        thisOrder.CHECK.pay(method);
        return true;
    }

    public void getInfo() {
        Console.WriteLine($"Hello, my name is {Name}, my email and phone is {Email}, {Phone}.");
        if (hasMembership) {
            Console.WriteLine($"I have a membership, and my current level is {membershipLevel}, my current point is {membershipCoffeePts}");
        }
    }
}