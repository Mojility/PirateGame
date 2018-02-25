using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuRenderer : MonoBehaviour {

	private Canvas canvas;
	void Start () {
		canvas = GetComponentInChildren(typeof(Canvas)) as Canvas;
		hideCanvas();
	}

	public void hideCanvas() {
		canvas.enabled = false;
	}

	public void showCanvas() {
		canvas.enabled = true;
	}
	

	void Update () {
		
	}
}
