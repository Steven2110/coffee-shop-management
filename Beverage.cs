abstract class Beverage {
    Guid drinkID;
    string name;
    double volume;
    double price;
    DrinkType drinkType;

    public Beverage(string name, double volume, double price, DrinkType drinkType) {
        drinkID = Guid.NewGuid();
        this.name = name;
        this.volume = volume;
        this.price = price;
        this.drinkType = drinkType;
    }

    public string Name {
        get {
            return name;
        }
    }

    public double Price {
        get {
            return price;
        }
    }

    public abstract void brew();
}

class EspressoBased: Beverage {
    double coffeeRequired;

    public EspressoBased(string name, double volume, double price, DrinkType drinkType, double coffeeRequired): base(name, volume, price, drinkType) {
        this.coffeeRequired = coffeeRequired;
    }

    public override void brew() {
        Console.WriteLine($"Brewing your {Name}, please wait!");
        Console.WriteLine($"{Name} is done! Enjoy your drink!");
    }
}

class FilterCoffee: Beverage {
    double coffeeRequired;

    public FilterCoffee(string name, double volume, double price, DrinkType drinkType, double coffeeRequired): base(name, volume, price, drinkType) {
        this.coffeeRequired = coffeeRequired;
    }

    public override void brew() {
        Console.WriteLine($"Brewing your {Name}, please wait!");
        Console.WriteLine($"{Name} is done! Enjoy your drink!");
    }
}

class MilkCoffee: Beverage {
    double coffeeRequired;

    public MilkCoffee(string name, double volume, double price, DrinkType drinkType, double coffeeRequired): base(name, volume, price, drinkType) {
        this.coffeeRequired = coffeeRequired;
    }

    public override void brew() {
        Console.WriteLine($"Brewing your {Name}, please wait!");
        Console.WriteLine($"{Name} is done! Enjoy your drink!");
    }
}


