using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBeAte : MonoBehaviour {
	private GameObject cat;
	private bool catInRange;

	// Use this for initialization
	void Start () {
		cat = GameObject.FindGameObjectWithTag ("Cat");	
	}
	
	// Update is called once per frame
	void Update () {
		if (catInRange) {
			gameObject.SetActive (false);
		}
	}

	private void OnTriggerEnter(Collider other){
		if (other.tag == cat.tag)
			catInRange = true;
	}

	private void OnTriggerExit(Collider other){
		if (other.tag == cat.tag)
			catInRange = false;
	}



}
