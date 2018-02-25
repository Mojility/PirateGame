using UnityEngine;

public class GameEngineController : MonoBehaviour {
    private GameEngine _gameEngine;

    public MenuRenderer menuRenderer;

    void Start() {
        Chapter chapter1 = new Chapter1();
        _gameEngine = new GameEngine(new Chapter[] {chapter1});
    }

    void Update() { }

    public void startInteraction(InteractableController interactableController) {
        menuRenderer.showCanvas(interactableController.currentMenu());
    }
}