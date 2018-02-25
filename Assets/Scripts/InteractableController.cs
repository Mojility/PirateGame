using UnityEngine;

public class InteractableController : MonoBehaviour {
	
	protected Interactable interactable;

	void Start () {
		
	}
	
	void Update () {
		
	}

	public Menu currentMenu() {
		return interactable.currentMenu();
	}

	public void select(MenuOption option) {
		interactable.@select(option);
	}
}
