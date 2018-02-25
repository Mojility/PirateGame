using System.Runtime.InteropServices;
using NUnit.Framework;

namespace Editor {
    public class InteractableMultiplePreconditionTests {
        private Interactable _interactable;
        private Menu _notMetMenu;
        private Menu _metMenu;
        private Goal[] _singlePrecondition;
        private Goal[] _noPreconditions;
        private Goal _preconditionGoal;

        [SetUp]
        public void SetUp() {
            _interactable = new Interactable();

            _notMetMenu = new Menu(
                "You have not met the precondition.",
                new MenuOption[] { new MenuOption() { value = "OK", action = MenuOption.Action.Progress } });

            _metMenu = new Menu(
                "Avast, you have met the preconditions!",
                new MenuOption[] { new MenuOption() { value = "OK", action = MenuOption.Action.Progress } });

            _preconditionGoal = new Goal("DummyPrecondition");
            _singlePrecondition = new Goal[] {_preconditionGoal};
            _noPreconditions = new Goal[] {  };

            _interactable.addMenuSet(new Menu[] {_notMetMenu}, _noPreconditions, new Goal("WontSeeThis"));
            _interactable.addMenuSet(new Menu[] {_metMenu}, _singlePrecondition, new Goal("NorThis"));
        }

        [Test]
        public void TestSimplePreconditionNotMet() {
            var currentMetGoals = new Goal[] { };

            Menu menu = _interactable.currentMenu(currentMetGoals);

            Assert.AreEqual(_notMetMenu, menu);
        }

        [Test]
        public void TestSimplePreconditionMet() {
            var currentMetGoals = new Goal[] {_preconditionGoal};

            Menu menu = _interactable.currentMenu((currentMetGoals));

            Assert.AreEqual(_metMenu, menu);
        }

        [Test]
        public void TestProgressionAlongOriginalMenuWhenPreconditionsMet() {
            Menu menu1 = _interactable.currentMenu(new Goal[] { });
            Menu menu2 = _interactable.currentMenu(new Goal[] {_preconditionGoal});

            Assert.AreEqual(_notMetMenu, menu1);
            Assert.AreEqual(_notMetMenu, menu2);
        }

        [Test]
        public void TestCompletionOfOriginalMenuAllowsSecondMenu() {
            Menu menu1 = _interactable.currentMenu(new Goal[] { });
            _interactable.select(_notMetMenu.options[0]);

            Menu menu2 = _interactable.currentMenu(new Goal[] {_preconditionGoal});
            
            Assert.AreEqual(_metMenu, menu2);
        }
    }
}