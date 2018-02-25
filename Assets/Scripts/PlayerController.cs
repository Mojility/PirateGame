﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D playerRB;
	private Collider2D possibleInteractive;
	private Vector3 oldPosition;
	private float speed = 0.25f;
	private bool collisionActive;
	private enum possiblePlayerStates {Active, InMenu};
	private int playerState;

	public GameEngineController gameEngineController;
	
	void Start () {
		playerRB = GetComponent<Rigidbody2D>();
		collisionActive = false;
		playerState = (int)possiblePlayerStates.Active;
	}
	
	void Update () {
		if(playerState == (int)possiblePlayerStates.Active) {
			if(Input.GetButton("Horizontal") && !collisionActive) {
				oldPosition = playerRB.transform.position;
				float horizontal = Input.GetAxis("Horizontal") * speed;
				Vector3 movement = new Vector3(horizontal, 0, 0);
				playerRB.MovePosition(playerRB.transform.position + movement);
			}
			if(Input.GetButton("Vertical") && !collisionActive) {
				oldPosition = playerRB.transform.position;
				float vertical = Input.GetAxis("Vertical") * speed;
				Vector3 movement = new Vector3(0, vertical, 0);
				playerRB.MovePosition(playerRB.transform.position + movement);
			}
		}
		if(Input.GetKeyDown(KeyCode.Return)) {
			if(possibleInteractive != null && playerState != (int)possiblePlayerStates.InMenu) {
				InteractableController interactableController = possibleInteractive.GetComponentInParent<InteractableController>();
				gameEngineController.startInteraction(interactableController);
				playerState = (int)possiblePlayerStates.InMenu;
			}
			else if(playerState == (int)possiblePlayerStates.InMenu) {
				playerState = (int)possiblePlayerStates.Active;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "Interactive") {
			possibleInteractive = other;
		}
		if(other.tag == "SolidObject") {
			playerRB.MovePosition(oldPosition);
			collisionActive = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "Interactive") {
			possibleInteractive = null;
		}
		if(other.tag == "SolidObject") {
			collisionActive = false;
		}
	}
}

