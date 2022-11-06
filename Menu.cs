class Menu {
    List<Beverage> beveragesOnMenu = new List<Beverage>();
    List<EspressoBased> espressoOnMenu = new List<EspressoBased>();
    List<FilterCoffee> filterCoffeesOnMenu = new List<FilterCoffee>();
    List<MilkCoffee> milkCoffeesOnMenu = new List<MilkCoffee>();

    public void addEspressoBased(EspressoBased beverage) {
        beveragesOnMenu.Add(beverage);
        espressoOnMenu.Add(beverage);
    }
    public void addMilkBased(MilkCoffee beverage) {
        beveragesOnMenu.Add(beverage);
        milkCoffeesOnMenu.Add(beverage);
    }
    public void addFilterCoffee(FilterCoffee beverage) {
        beveragesOnMenu.Add(beverage);
        filterCoffeesOnMenu.Add(beverage);
    }

    public List<Beverage> Beverages {
        get {
            return beveragesOnMenu;
        }
    }
}