using NUnit.Framework;

public class InteractableTests {

	private Menu _firstMenu;
	private Menu _secondMenu;
	private Menu _thirdMenu;
	private Menu _fourthMenu;
	private Menu _fifthMenu;
	
	private Goal _goal;
	private Interactable _potentialCrewman;

	[SetUp]
	public void SetUp() {
		_firstMenu = new Menu(
			"You see a disheveled stranger.",
			new MenuOption[] {
				new MenuOption() { value = "Ignore them.", action = MenuOption.Action.Dismiss },
				new MenuOption() { value = "Ask, 'How did you end up here?'", action = MenuOption.Action.Progress }
			});
		
		_secondMenu = new Menu(
			"The stranger says, 'I was hired to stay here and wait for when I am needed.'",
			new MenuOption[] {
				new MenuOption() { value = "Ask, 'What would you be needed for?'", action = MenuOption.Action.Progress }
			});

		_thirdMenu = new Menu(
			"The stranger says, 'That's between me and my employer.'",
			new MenuOption[] {
				new MenuOption() { value = "Fight", action = MenuOption.Action.Dismiss },
				new MenuOption() { value = "Say, 'How would you like a new job as my first mate?'", action = MenuOption.Action.Progress }, 				
			});

		_fourthMenu = new Menu(
			"The stranger says, 'You can't offer me more than my current employer.'",
			new MenuOption[] {
				new MenuOption() { value = "Say, 'Not in gold, but I can offer the freedom and adventure of the life of a pirate!'", action = MenuOption.Action.Progress }
			});

		_fifthMenu = new Menu(
			"The stranger grins and says, 'I have been dying of boredom...'",
			new MenuOption[] {
				new MenuOption() { value = "You have gained First Mate Riley.", action = MenuOption.Action.Progress },
			});
		
		_goal = new Goal("MakeFriend");
		_potentialCrewman = new Interactable(new Menu[] { _firstMenu, _secondMenu, _thirdMenu, _fourthMenu, _fifthMenu }, _goal);
	}
	
	[Test]
	public void PotentialCrewmanPresentsFirstMenu() {
		Assert.IsFalse(_potentialCrewman.isGoalMet());
		Assert.AreEqual(_potentialCrewman.currentMenu(), _firstMenu);
	}

	[Test]
	public void PotentialCrewmanAdvancesWithFirstMenuOptionOne() {
		_potentialCrewman.select(_firstMenu.options[0]);

		Assert.IsFalse(_potentialCrewman.isGoalMet());
		Assert.AreEqual(_potentialCrewman.currentMenu(), _firstMenu);
	}

	[Test]
	public void PotentialCrewmanDoesNotAdvanceWithMenuOptionTwo() {
		_potentialCrewman.select(_firstMenu.options[1]);

		Assert.IsFalse(_potentialCrewman.isGoalMet());
		Assert.AreEqual(_potentialCrewman.currentMenu(), _secondMenu);
	}

	[Test]
	public void PotentialCrewmanCanMeetGoal() {
		_potentialCrewman.select(_firstMenu.options[1]);
		_potentialCrewman.select(_secondMenu.options[0]);
		_potentialCrewman.select(_thirdMenu.options[1]);
		_potentialCrewman.select(_fourthMenu.options[0]);
		_potentialCrewman.select(_fifthMenu.options[0]);
		
		Assert.IsTrue(_potentialCrewman.isGoalMet());
	}
	
}
