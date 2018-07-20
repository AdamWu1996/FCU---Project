using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour {

	public float speed = 6f;
	private Vector3 movement;
	private Animator anim;
	private Rigidbody catRigidbody;
	private RectTransform handle;

	private IEnumerator Rotation(){
		
		while (true) {
			transform.LookAt(new Vector3(transform.position.x + movement.x*60
				,0
				,transform.position.z + movement.y*60));
			yield return null;
		}
	}

	void Awake(){
		anim = GetComponent<Animator>();
		catRigidbody = GetComponent<Rigidbody> ();
	}

	void Move(float h,float v){
		movement.Set (h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		catRigidbody.MovePosition (transform.position + movement);
	}

	void Animating(float h,float v){
		bool running = h != 0 || v != 0;
		anim.SetBool ("isRun", running);
	}

	void FixedUpdate(){
		float v = CrossPlatformInputManager.GetAxis ("Vertical");
		float h = CrossPlatformInputManager.GetAxis ("Horizontal");
		Move (h, v);
		Animating(h, v);
	}

}
