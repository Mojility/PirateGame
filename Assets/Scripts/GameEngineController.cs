using UnityEngine;

public class GameEngineController : MonoBehaviour {
    private GameEngine _gameEngine;

    public MenuRenderer menuRenderer;
    public InteractableController noticedInteractableController;
    public PlayerController playerController;

    void Start() {
        Chapter chapter1 = new Chapter1();
        _gameEngine = new GameEngine(new Chapter[] {chapter1});

        noticedInteractableController = null;
    }

    void Update() {
        if (menuRenderer.menuIsActive) {
            handleMenuInput();
        } else {
            handlePlayerInput();
        }
    }

    private void handlePlayerInput() {
        if (Input.GetButton("Horizontal")) {
            playerController.movePlayerHorizontal();
        }

        if (Input.GetButton("Vertical")) {
            playerController.movePlayerVertical();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            startInteraction();
        }
    }

    private void handleMenuInput() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            menuRenderer.moveSelectionUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            menuRenderer.moveSelectionDown();
        }

        if (Input.GetKeyDown(KeyCode.Return)) {
            var action = menuRenderer.activateSelection();
            if (action == MenuOption.Action.Dismiss) {
                menuRenderer.dismissMenu();
            }
        }
    }

    public void noticedInteractable(InteractableController interactableController) {
        noticedInteractableController = interactableController;
    }

    public void lostInteractable() {
        noticedInteractableController = null;
    }

    public void startInteraction() {
        if (noticedInteractableController != null) {
            _gameEngine.startInteraction(noticedInteractableController.interactable);
            menuRenderer.showCanvas(_gameEngine.currentInteractableMenu());
        }
    }

    public MenuOption.Action select(int selectedOptionIndex) {
        MenuOption.Action action = _gameEngine.select(selectedOptionIndex);
        if (noticedInteractableController.interactable.isGoalMet()) {
            menuRenderer.dismissMenu();
        } else {
            menuRenderer.showCanvas(_gameEngine.currentInteractableMenu());
        }

        return action;
    }
}