class CoffeeShop {
    string name;
    string address;
    string phone;
    string dateOpened;
    double revenue;

    List<Employee> employees = new List<Employee>();
    List<Customer> customers = new List<Customer>();
    // Menu menu;

    public CoffeeShop() {
        name = "MyCoffeeShop";
        address = "Buyanovskiy pereulok 3a";
        phone = "999999999";
        dateOpened = DateTime.Now.ToString("dd.MM.yy");
        revenue = 0;

        employees.Add(new Manager(40, "John Doe Manager", "johndoem@t.com", "123123"));
        employees.Add(new Barista(24, "John Doe Barista", "johndoeb@t.com", "123321"));
        employees.Add(new Cashier(21, "John Doe Cashier", "johndoec@t.com", "123456"));
    }

    public void getEmployees() {
        foreach(Employee employee in employees) {
            Console.WriteLine(employee.ToString());
        }
    }

    public bool registerNewCustomer(Person person) {
        customers.Add(new Customer(person.Name, person.Email, person.Phone));
        return true;
    }

    public bool hireEmployee(Person person) {
        if(person.Name.Contains("John")) {
            Random rnd = new Random();
            if (rnd.Next(1, 4) == 1) {
                double salary = rnd.Next(1, 400) * 0.4;
                employees.Add(new Manager(salary, person.Name, person.Email, person.Phone));
            } else if (rnd.Next(1, 4) == 2) {
                double salary = rnd.Next(1, 400) * 0.2;
                employees.Add(new Barista(salary, person.Name, person.Email, person.Phone));
            } else if (rnd.Next(1, 4) == 3) {
                double salary = rnd.Next(1, 400) * 0.1;
                employees.Add(new Cashier(salary, person.Name, person.Email, person.Phone));
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
}