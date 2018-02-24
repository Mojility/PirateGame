using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D playerRB;

	void Start () {
		playerRB = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		if(Input.GetKeyDown(KeyCode.RightArrow)) {
			playerRB.MovePosition(playerRB.position + Vector2.right);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)) {
			playerRB.MovePosition(playerRB.position + Vector2.left);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			playerRB.MovePosition(playerRB.position + Vector2.up);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)) {
			playerRB.MovePosition(playerRB.position + Vector2.down);
		}
	}
}

