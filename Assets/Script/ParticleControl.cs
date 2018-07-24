using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleControl : MonoBehaviour {

	public ParticleSystem particleSystem;
	private bool isLoving;
	private int choice;
	private float touchRayLength = 100f;

	void Awake () {
		particleSystem.Stop ();
	}

	void Touching(){
		Ray touchRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit catHit;
		if(Physics.Raycast(touchRay,out catHit,touchRayLength)){
			if (catHit.transform.tag == "Cat" && !particleSystem.isPlaying) {
				particleSystem.Play ();
			} else if(catHit.transform.tag != "Cat"){
				particleSystem.Stop ();
			}
		}
	}

	void Start(){
		
	}

	void Update () {
		Touching ();
	}

}
