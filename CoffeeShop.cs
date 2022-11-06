class CoffeeShop {
    string name;
    string address;
    string phone;
    string dateOpened;
    double revenue;

    public List<Employee> employees = new List<Employee>();
    public List<Manager> managers = new List<Manager>();
    public List<Cashier> cashiers = new List<Cashier>();
    public List<Barista> baristas = new List<Barista>();
    public List<Customer> customers = new List<Customer>();
    Menu menu;

    public CoffeeShop() {
        name = "MyCoffeeShop";
        address = "Buyanovskiy pereulok 3a";
        phone = "999999999";
        dateOpened = DateTime.Now.ToString("dd.MM.yy");
        revenue = 0;

        Manager newManager = new Manager(40, "John Doe Manager", "johndoem@t.com", "123123", this);
        Barista newBarista = new Barista(24, "John Doe Barista", "johndoeb@t.com", "123321", this);
        Cashier newCashier = new Cashier(21, "John Doe Cashier", "johndoec@t.com", "123456", this);

        employees.Add(newManager);
        managers.Add(newManager);
        employees.Add(newBarista);
        baristas.Add(newBarista);
        employees.Add(newCashier);
        cashiers.Add(newCashier);
    }

    public void getEmployees() {
        foreach(Employee employee in employees) {
            Console.WriteLine(employee.Name + ", Role: " + employee.ToString());
        }
    }

    public bool registerNewCustomer(Customer customer) {
        customers.Add(customer);
        return true;
    }

    public bool hireEmployee(Person person) {
        if(person.Name.Contains("John")) {
            Random rnd = new Random();
            if (rnd.Next(1, 4) == 1) {
                double salary = rnd.Next(1, 400) * 0.4;
                Manager newManager = new Manager(salary, person.Name, person.Email, person.Phone, this);
                employees.Add(newManager);
                managers.Add(newManager);
            } else if (rnd.Next(1, 4) == 2) {
                double salary = rnd.Next(1, 400) * 0.2;
                Barista newBarista = new Barista(salary, person.Name, person.Email, person.Phone, this);
                employees.Add(newBarista);
                baristas.Add(newBarista);
            } else if (rnd.Next(1, 4) == 3) {
                double salary = rnd.Next(1, 400) * 0.1;
                Cashier newCashier = new Cashier(salary, person.Name, person.Email, person.Phone, this);
                employees.Add(newCashier);
                cashiers.Add(newCashier);
            }
            return true;
        }
        return false;
    }

    public bool paySalary() {
        double totalSalary = 0;
        foreach(Employee employee in employees) {
            totalSalary += employee.Salary;
        }
        if(totalSalary < revenue) {
            revenue -= totalSalary;
            return true;
        }
        Console.WriteLine("Can't pay all employee salary. Need to receive more order!!");
        return false;
    }

    public Menu MENU {
        get {
            return menu;
        } set {
            menu = value;
        }
    }
}