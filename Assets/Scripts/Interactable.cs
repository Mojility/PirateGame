public class Interactable {
    public Menu[] menus;
    public Goal goalOffered;

    private int currentMenuIndex = 0;

    public Interactable(Menu[] menus, Goal goal) {
        this.menus = menus;
        goalOffered = goal;
    }
    public Interactable() {}

    public Menu currentMenu() {
        return this.menus[currentMenuIndex];
    }
    
    public MenuOption.Action select(MenuOption option) {
        if (option.action == MenuOption.Action.Progress) {
            currentMenuIndex++;
        }

        return option.action;
    }

    public bool isGoalMet() {
        return currentMenuIndex >= menus.Length - 1;
    }
}