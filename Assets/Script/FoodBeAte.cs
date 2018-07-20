using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodBeAte : MonoBehaviour {
	private GameObject cat;
	private GameObject sliderObj;
	private Slider slider;
	private bool catInRange;
	private int tomato = 10;

	// Use this for initialization
	void Start () {
		cat = GameObject.FindGameObjectWithTag ("Cat");	
		sliderObj = GameObject.Find ("FullSlider");
		slider = sliderObj.GetComponentInChildren<Slider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (catInRange) {
			gameObject.SetActive (false);
			slider.value += tomato;
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
