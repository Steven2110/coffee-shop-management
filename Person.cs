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
    public abstract Customer registerCustomer(Person person);
}

class Manager: Employee {

    public Manager(double salary, string name, string email, string phone): base(salary, name, email, phone) {

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
    public override Customer registerCustomer(Person person) {
        Customer newCustomer = new Customer(this);
    }

}

class Cashier: Employee {
    List<Order> todaysOrder = new List<Order>();
    public Cashier(double salary, string name, string email, string phone): base(salary, name, email, phone) {

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
}

class Barista: Employee {
    public Barista(double salary, string name, string email, string phone): base(salary, name, email, phone) {

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
}

class Customer: Person {
    Guid customerID;
    bool hasMembership;

#nullable enable
    MembershipLevel? membershipLevel = null;

    int membershipCoffeePts;

#nullable enable
    string? membershipDateCreated = null;

    // List<Order> orders;

    public Customer(string name, string email, string phone): base(name, email, phone) {
        customerID = Guid.NewGuid();
        hasMembership = false;
        membershipCoffeePts = 0;
    }

    public bool buyMembership() {
        return false;
    }

    public bool makeOrder(Menu menu, Cashier cashier) {
        Random random = new Random();

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
        
        if (thisOrder.CHECK.pay(method)) {
            return true;
        }
        else {
            return false;
        }
    }

    public void getInfo() {
        Console.WriteLine($"Hello, my name is {Name}, my email and phone is {Email}, {Phone}.");
        if (hasMembership) {
            Console.WriteLine($"I have a membership, and my current level is {membershipLevel}, my current point is {membershipCoffeePts}");
        }
    }
}