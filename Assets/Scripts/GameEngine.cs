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
