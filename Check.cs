class Check {
    Guid checkID;
    double amount;
    bool isPaid;
    Order order;
    Payment payment;

    public Check(Order order) {
        checkID = Guid.NewGuid();
        this.order = order;
        amount = calculateAmount();
        isPaid = false;
    }

    private double calculateAmount() {
        double totalPrice = 0;
        foreach(Beverage beverage in this.order.Beverages) {
            totalPrice += beverage.Price;
        }
        return totalPrice;
    }

    public bool pay(PaymentMethod by) {
        calculateAmount();
        if (by == PaymentMethod.CreditCard) {
            payment = new CreditCard(order.getCustomerCreditCard(), order.getCustomerCreditCardName());
        } else if (by == PaymentMethod.Cash) {
            payment = new Cash();
        }

        if (payment.initiateTransaction()) {
            isPaid = true;
            printCheck();
            return true;
        }
        return false;
    }

    public string printCheck() {
        string check = "This check contains\n";
        int i = 1;
        foreach(Beverage beverage in order.Beverages) {
            string detail = $"{i}. {beverage.Name}.....{beverage.Price}\n";
            check += detail;
        }
        return check;
    }

    public double Amount {
        get {
            return amount;
        }
    }
}