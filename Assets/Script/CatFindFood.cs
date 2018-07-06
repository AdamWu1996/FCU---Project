using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatFindFood : MonoBehaviour {

	private Transform food;
	private NavMeshAgent nav;

	void Awake(){
		nav = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		food = GameObject.FindGameObjectWithTag ("Food").transform;
		nav.destination = food.position;
	}
}
