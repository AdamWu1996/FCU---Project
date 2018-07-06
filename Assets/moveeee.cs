using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveeee : MonoBehaviour {

	float moveSpeed = 5f;
	Rigidbody rb;
	Touch touch;
	Vector3 touchPosition, whereToMove;
	bool isMoving = false;
	float previousDistanceToTouchPos, currentDistanceToTouchPos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}


	// Update method actually does the work:
	void Update() {
		if (isMoving)
			currentDistanceToTouchPos = (touchPosition - transform.position).magnitude;

		if (Input.touchCount > 0) {
			touch = Input.GetTouch (0);

			if (touch.phase == TouchPhase.Began) {
				previousDistanceToTouchPos = 0;
				currentDistanceToTouchPos = 0;
				isMoving = true;
				touchPosition = Camera.main.ScreenToWorldPoint (touchPosition);
				touchPosition.z = 0;
				whereToMove = (touchPosition - transform.position).normalized;
				rb.velocity = new Vector3 (whereToMove.x * moveSpeed, whereToMove.y, 0);
			}
		}

		if (currentDistanceToTouchPos > previousDistanceToTouchPos) {
			isMoving = false;
			rb.velocity = Vector3.zero;
		}

		if (isMoving)
			previousDistanceToTouchPos = (touchPosition - transform.position).magnitude;
	}
}
