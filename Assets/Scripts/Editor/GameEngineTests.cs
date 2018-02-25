using System.Security.Policy;
using NUnit.Framework;

public class GameEngineTests {
	
	private Menu _firstMenu;
	private Goal _goal;
	private Chapter _chapter1;
	private GameEngine _gameEngine;
	private Interactable _potentialCrewman;

	public enum Scenes {
		Island,
		Cave
	};

	[SetUp]
	public void SetUp() {
		_firstMenu = new Menu("You see a disheveled stranger.", new MenuOption[] {
			new MenuOption() { value = "Ignore them.", action = MenuOption.Action.DoNothing },
			new MenuOption() { value = "Ask, 'How did you end up here?'", action = MenuOption.Action.Progress }
		});
		
		_goal = new Goal("MakeFriend");
		_potentialCrewman = new Interactable(new Menu[] { _firstMenu }, _goal);
		_chapter1 = new Chapter(new Interactable[] { _potentialCrewman });
		
		_gameEngine = new GameEngine(new Chapter[] { _chapter1 });
	}
	
	[Test]
	public void GameEngineStartsOnFirstChapter() {
		Assert.AreEqual(_chapter1, _gameEngine.currentChapter);
	}


	[Test]
	public void GameEngineCanStartInteraction() {
		// When PlayerController encounters an InteractableController
		// Then the PlayerController starts the GameEngine to start the interaction
		_gameEngine.startInteraction(_potentialCrewman);
		
		Assert.AreEqual(_firstMenu, _gameEngine.currentInteractableMenu());
	}
}
