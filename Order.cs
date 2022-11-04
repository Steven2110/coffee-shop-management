class Order {
    Guid orderID;
    Check check;
    List<Beverage> beveragesOnOrder = new List<Beverage>();
    Customer customer;

    public Order(Customer customer) {
        orderID = Guid.NewGuid();
        this.customer = customer;
        check = new Check(this);
    }    

    public bool addBeverage(Beverage beverage) {
        beveragesOnOrder.Add(beverage);
        return false;
    }

    public List<Beverage> Beverages {
        get {
            return beveragesOnOrder;
        }
    }

    public Check CHECK {
        get {
            return check;
        }
    }

    public string getCustomerCreditCard() {
        return customer.CreditCardNumber;
    }

    public string getCustomerCreditCardName() {
        return customer.Name;
    }

    public bool removeBeverage(Beverage beverage) {
        return false;
    }
}