abstract class Payment {
    Guid paymentID;
    string datePaid;
    Check check;

    public abstract bool initiateTransaction();

    public Guid ID {
        get {
            return paymentID;
        } set {
            paymentID = value;
        }
    }

    public string DatePaid {
        get {
            return datePaid;
        } set {
            datePaid = value;
        }
    }

    public Check CHECK {
        get {
            return check;
        }
    }
}

class CreditCard: Payment {
    string cardNumber;
    string nameOnCard;

    public CreditCard(string cardNumber, string nameOnCard) {
        this.cardNumber = cardNumber;
        this.nameOnCard = nameOnCard;
    }

    public override bool initiateTransaction() {
        if (cardNumber.ToString().Count() == 16) {
            ID = Guid.NewGuid();
            DatePaid = DateTime.Now.ToString("dd.MM.yy");
            return true;
        }
        return false;
    }
}

class Cash: Payment {
    double cashTendered;

    public override bool initiateTransaction()
    {
        double amountNeededToBePaid = CHECK.Amount;
        Random rand = new Random();
        cashTendered = Math.Floor(amountNeededToBePaid / 10) + rand.Next(2, 10) * 5;
        if (cashTendered < amountNeededToBePaid) {
            return false;
        }
        ID = Guid.NewGuid();
        DatePaid = DateTime.Now.ToString("dd.MM.yy");
        return true;
    }
}