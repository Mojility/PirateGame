using System.Collections.Generic;

public class GameEngine {
    private readonly Chapter[] _chapters;

    private List<Goal> goalsMet = new List<Goal>();
    
    public Chapter currentChapter;
    private Interactable _currentInteractable;

    public GameEngine(Chapter[] chapters) {
        _chapters = chapters;

        currentChapter = _chapters[0];
    }

    public Menu interact(Interactable interactable) {
        return interactable.currentMenu(goalsMet.ToArray());
    }

    public void startInteraction(Interactable interactable) {
        _currentInteractable = interactable;
    }

    public Menu currentInteractableMenu() {
        return _currentInteractable.currentMenu(goalsMet.ToArray());
    }

    public MenuOption.Action select(int selectedOptionIndex) {
        MenuOption.Action action = _currentInteractable.@select(currentInteractableMenu().options[selectedOptionIndex]);
        if (_currentInteractable.isGoalMet()) {
            goalsMet.Add(_currentInteractable.currentGoalOffered());
        }
        return action;
    }
}
