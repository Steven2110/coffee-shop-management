class Menu {
    List<Beverage> beveragesOnMenu = new List<Beverage>();

    public void addBeverage(string name, double volume, double price, DrinkType type) {
        Random rand = new Random();
        int randValue = rand.Next(0, 100);
        DrinkType drinkType;
        if (randValue % 2 == 0 && randValue < 66) {
            string beverageName = name + "(Espresso based)";
            if (rand.Next(0, 100) % 2 == 0) {
                drinkType = DrinkType.Iced;
            } else {
                drinkType = DrinkType.Hot;
            }
            beveragesOnMenu.Add(new EspressoBased(beverageName, volume, price, drinkType, rand.Next(15, 20) * 1.0));
        } else if (randValue % 2 == 1 && randValue < 66) {
            string beverageName = name + "(with Milk)";
            if (rand.Next(0, 100) % 2 == 0) {
                drinkType = DrinkType.Iced;
            } else {
                drinkType = DrinkType.Hot;
            }
            beveragesOnMenu.Add(new MilkCoffee(beverageName, volume, price, drinkType, rand.Next(15, 20) * 1.0));
        } else if (randValue >= 66) {
            string beverageName = name + "(Filtered)";
            if (rand.Next(0, 100) % 2 == 0) {
                drinkType = DrinkType.Iced;
            } else {
                drinkType = DrinkType.Hot;
            }
            beveragesOnMenu.Add(new FilterCoffee(beverageName, volume, price, drinkType, rand.Next(15, 30) * 1.0));
        }
    }

    public List<Beverage> Beverages {
        get {
            return beveragesOnMenu;
        }
    }
}