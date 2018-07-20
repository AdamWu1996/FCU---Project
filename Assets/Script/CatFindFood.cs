using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CatFindFood : MonoBehaviour {
	private Animator anim;
	private Transform food;
	private NavMeshAgent nav;

	void Awake(){
		anim = GetComponent<Animator>();
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (food = GameObject.FindGameObjectWithTag ("Food").transform) {
			nav.destination = food.position;
			anim.SetBool ("isRun", true);
		}
			
		//food = GameObject.FindGameObjectWithTag ("Food").transform;
		
	}
}
