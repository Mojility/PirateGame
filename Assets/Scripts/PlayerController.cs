using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private float _speed = 0.25f;

    private Rigidbody2D playerRB;
    private Vector3 oldPosition;
    private bool _collisionActive;

    public GameEngineController gameEngineController;

    void Start() {
        playerRB = GetComponent<Rigidbody2D>();
        _collisionActive = false;
    }

    void Update() { }

    public void movePlayerVertical() {
        if (!_collisionActive) {
            oldPosition = playerRB.transform.position;
            float vertical = Input.GetAxis("Vertical") * _speed;
            Vector3 movement = new Vector3(0, vertical, 0);
            playerRB.MovePosition(playerRB.transform.position + movement);
        }
    }

    public void movePlayerHorizontal() {
        if (!_collisionActive) {
            oldPosition = playerRB.transform.position;
            float horizontal = Input.GetAxis("Horizontal") * _speed;
            Vector3 movement = new Vector3(horizontal, 0, 0);
            playerRB.MovePosition(playerRB.transform.position + movement);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Interactive") {
            InteractableController interactableController = other.GetComponentInParent<InteractableController>();
            gameEngineController.noticedInteractable(interactableController);
        }

        if (other.tag == "SolidObject") {
            playerRB.MovePosition(oldPosition);
            _collisionActive = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Interactive") {
            gameEngineController.lostInteractable();
        }

        if (other.tag == "SolidObject") {
            _collisionActive = false;
        }
    }
}