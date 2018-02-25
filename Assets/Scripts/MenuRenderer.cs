using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuRenderer : MonoBehaviour {

	private Canvas canvas;
	private Text menuText;
	void Start () {
		canvas = GetComponentInChildren<Canvas>();
		menuText = GetComponentInChildren<Text>();
		hideCanvas();
	}

	public void hideCanvas() {
		canvas.enabled = false;
	}

	public void showCanvas(Menu newMenu) {
		canvas.enabled = true;
		menuText.text = newMenu.introduction;
	}
	

	void Update () {
		if(Input.GetKeyDown(KeyCode.Return)) {
			hideCanvas();
		}
	}
}
