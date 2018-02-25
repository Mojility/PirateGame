using NUnit.Framework;

public class InteractableTests {

	private Menu _firstMenu;
	private Menu _secondMenu;
	
	private Goal _achievableGoal;
	private Interactable _interactable;
	private Goal[] _emptyGoals = new Goal[] {};

	[SetUp]
	public void SetUp() {
		_firstMenu = new Menu(
			"You see a disheveled stranger.",
			new MenuOption[] {
				new MenuOption() { value = "Ignore them.", action = MenuOption.Action.Dismiss },
				new MenuOption() { value = "Say, 'Join me!'", action = MenuOption.Action.Progress }
			});
		
		_secondMenu = new Menu(
			"The stranger grins and says, 'I have been dying of boredom...'",
			new MenuOption[] {
				new MenuOption() { value = "You have gained First Mate Riley.", action = MenuOption.Action.Progress },
			});

		_achievableGoal = new Goal("MakeFriend");

		_interactable = new Interactable();
		
		var preconditions = _emptyGoals; 
		_interactable.addMenuSet(new Menu[] { _firstMenu, _secondMenu }, preconditions, _achievableGoal);
	}
	
	[Test]
	public void PotentialCrewmanPresentsFirstMenu() {
		Assert.IsFalse(_interactable.isGoalMet());
		Assert.AreEqual(_firstMenu, _interactable.currentMenu(_emptyGoals));
	}

	[Test]
	public void PotentialCrewmanAdvancesWithFirstMenuOptionOne() {
		_interactable.select(_firstMenu.options[0]);

		Assert.IsFalse(_interactable.isGoalMet());
		Assert.AreEqual(_firstMenu, _interactable.currentMenu(_emptyGoals));
	}

	[Test]
	public void PotentialCrewmanDoesNotAdvanceWithMenuOptionTwo() {
		_interactable.select(_firstMenu.options[1]);

		Assert.IsFalse(_interactable.isGoalMet());
		Assert.AreEqual(_firstMenu, _interactable.currentMenu(_emptyGoals));
	}

	[Test]
	public void PotentialCrewmanCanMeetGoal() {
		_interactable.select(_firstMenu.options[1]);
		_interactable.select(_secondMenu.options[0]);
		
		Assert.IsTrue(_interactable.isGoalMet());
	}
	
}
