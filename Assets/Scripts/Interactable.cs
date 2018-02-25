using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MenuSet {
    public Menu[] menus;
    public Goal[] preconditions;
    public Goal goalOffered;
    public bool isStarted = false;
    public bool isFinished = false;
}

public class Interactable {

    private List<MenuSet> menuSets = new List<MenuSet>();
    
    private int currentMenuIndex = 0;
    private int currentMenuSet = 0;

    public Interactable() {}

    public Menu currentMenu(Goal[] currentMetGoals) {
        if (!menuSets[currentMenuSet].isStarted)
            chooseNextBestMenuSet(currentMetGoals);
        return menuSets[currentMenuSet].menus[currentMenuIndex];
    }

    private void chooseNextBestMenuSet(Goal[] currentMetGoals) {
        for (int i = 0; i < menuSets.Count; i++) {
            if (containsAllPreconditions(menuSets[i].preconditions, currentMetGoals))
                currentMenuSet = i;
        }

        menuSets[currentMenuSet].isStarted = true;
        currentMenuIndex = 0;
    }

    private bool containsAllPreconditions(Goal[] preconditions, Goal[] metConditions) {
        foreach (var g in preconditions) {
            if (!metConditions.Contains(g)) return false;
        }
        return true;
    }
    
    // TODO: We should progress all the way through a menu[] before switching menuSets based on preconditions
    public MenuOption.Action select(MenuOption option) {
        if (option.action == MenuOption.Action.Progress) {
            currentMenuIndex++;
            if (currentMenuIndex >= menuSets[currentMenuSet].menus.Length) {
                menuSets[currentMenuSet].isFinished = true;
                menuSets[currentMenuSet].isStarted = false;
            }
        }

        return option.action;
    }

    public Goal currentGoalOffered() {
        return menuSets[currentMenuSet].goalOffered;
    }
    
    public bool isGoalMet() {
        return menuSets[currentMenuSet].isFinished;
    }

    public void addMenuSet(Menu[] menus, Goal[] preconditions, Goal achievableGoal) {
        menuSets.Add(new MenuSet() { menus = menus, preconditions =  preconditions, goalOffered = achievableGoal });
    }
}