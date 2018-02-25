using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RileyController : MonoBehaviour {

	private Riley riley;
	public MenuRenderer menuRenderer;

	void Start () {
		riley = new Riley();
	}

	public Menu currentMenu() {
		return riley.currentMenu();
	}

	void Update () {
		
	}
}
