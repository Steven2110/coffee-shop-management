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
        return true;
    }
}

class Cash: Payment {

    public override bool initiateTransaction()
    {
        return true;
    }
}