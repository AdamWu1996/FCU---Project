using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodCreation : MonoBehaviour {
	public GameObject food;
	public GameObject cat;

	private Animator anim;
	private AnimatorStateInfo asi;
	public float delayTime = 1f;
	public float repeatRate = 3f;
	public Transform[] spawnPoints; //產生食物的點座標
	private bool catIsFull = false;


	void Awake(){
		anim = cat.GetComponent<Animator> ();
	}

	private void catFullAction(){
		catIsFull = true;
	}

	private void OnEnable(){
		
	}

	private void OnDisable(){

	}

	public void Spawn(){

		if (GameObject.Find ("FullSlider").GetComponentInChildren<Slider> ().value < 100) {
			if (anim.GetCurrentAnimatorStateInfo (0).IsName ("Fatigue")) { //休息中
				Debug.Log ("休息中，無法進食");
			} else { //產生食物
				if (catIsFull) {
					CancelInvoke ("Spawn");
					return;
				}
				int pointIndex = Random.Range (0, spawnPoints.Length);
				Instantiate (food, spawnPoints [pointIndex].position, spawnPoints [pointIndex].rotation);
			}
		}
		else {
			Debug.Log ("我不餓了");
		}

	}

	void Update(){
		asi = anim.GetCurrentAnimatorStateInfo (0);
	}
}
