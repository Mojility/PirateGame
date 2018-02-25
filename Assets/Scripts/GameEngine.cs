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

    public enum Action { Dismiss, Progress }
}

public class Goal {
    private readonly string _makefriend;

    public Goal(string makefriend) {
        _makefriend = makefriend;
    }
}

public class GameEngine {
    private readonly Chapter[] _chapters;

    public Chapter currentChapter;
    private Interactable _currentInteractable;

    public GameEngine(Chapter[] chapters) {
        _chapters = chapters;

        currentChapter = _chapters[0];
    }

    public Menu interact(Interactable interactable) {
        return interactable.currentMenu();
    }

    public void startInteraction(Interactable interactable) {
        _currentInteractable = interactable;
    }

    public Menu currentInteractableMenu() {
        return _currentInteractable.currentMenu();
    }

    public MenuOption.Action select(int selectedOptionIndex) {
        return _currentInteractable.select(currentInteractableMenu().options[selectedOptionIndex]);
    }
}
