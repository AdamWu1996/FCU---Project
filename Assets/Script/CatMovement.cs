using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour {
	Rigidbody catRigidbody;
	Vector3 target;
	private int planeMask;
	Ray touchRay;
	RaycastHit hitPlane;

	void Start () {
		catRigidbody = GetComponent<Rigidbody> ();
		planeMask = LayerMask.GetMask ("Plane");
	}

	void Move(){

		for (int i = 0; i < Input.touchCount; i++) {
			
			if (Input.GetTouch (i).phase == TouchPhase.Began) {
				Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch(i).position);
				//catRigidbody.MovePosition (transform.position + Time.deltaTime);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount == 1) {
			if (Input.GetTouch(0).phase == TouchPhase.Began) {
				Vector3 target = Input.GetTouch(0).position;
				catRigidbody.MovePosition (target);
			}
		}
	}
}
