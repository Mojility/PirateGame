using UnityEditor;
using UnityEngine;

public class Menu {
    public string introduction;
    public MenuOption[] options;
    
    public Menu(string introduction, MenuOption[] options) {
        this.introduction = introduction;
        this.options = options;
    }
}

public class MenuOption {
    public string value;
    public Action action;

    public enum Action { DoNothing, Progress }
}

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
    
    public void select(MenuOption firstMenuOption) {
        if (firstMenuOption.action == MenuOption.Action.Progress) {
            currentMenuIndex++;
        }
    }

    public bool isGoalMet() {
        return currentMenuIndex >= menus.Length - 1;
    }
}

public interface Chapter { }

public class Goal {
    private readonly string _makefriend;

    public Goal(string makefriend) {
        _makefriend = makefriend;
    }
}

public class Chapter1 : Chapter {
    private readonly Interactable[] _interactables;

    public Chapter1(Interactable[] interactables) {
        _interactables = interactables;
    }

}

public class GameEngine {
    private readonly Chapter[] _chapters;

    public Chapter currentChapter;
    
    public GameEngine(Chapter[] chapters) {
        _chapters = chapters;

        currentChapter = _chapters[0];
    }

    public Menu interact(Interactable potentialCrewman) {
        return potentialCrewman.currentMenu();
    }
}
