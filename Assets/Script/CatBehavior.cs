using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatBehavior : MonoBehaviour {

	private Animator anim;
	private AnimatorStateInfo asi;

	/*  -------- Full -------- */
	private float startFull = 100;
	private Slider fullSlider;
	private float hungryPerSec = 10;
	private float fullTime;

	private void GraduallyHungry(){
		fullSlider.value -= hungryPerSec;
		fullTime = 0;
	}

	private void Full(){
		if(fullTime > 3)
			GraduallyHungry ();
	}

	/*  -------- Fatigue -------- */
	private float startFatigue = 100;
	private Slider fatigueSlider;
	private float tiredPerSec = 30;
	private float restPerSec = 30;
	private float fatigueTime;

	private void GraduallyTired(){
		
		if (fatigueTime > 3) {
			fatigueSlider.value -= tiredPerSec;
			fatigueTime = 0;
		}
	}

	private void GraduallyRest(){
		
		if (fatigueTime > 3) {
			fatigueSlider.value += restPerSec;
			fatigueTime = 0;
		}
	}

	private void Fatigue(){

		if (!asi.IsName ("Fatigue")) { //每過三單位且疲勞值>0
			
			if (fatigueSlider.value <= 0)
				anim.SetTrigger ("isFatigue");
			else 
				GraduallyTired ();	
		}
		else {
			
			if(fatigueSlider.value != 100)
				GraduallyRest ();
			else
				anim.SetTrigger("notFatigue");
		}
	}
		

		
	/*  -------- Main -------- */
	void Awake(){
		
		fatigueTime = fullTime = 0;
		fullSlider = GameObject.Find ("FullSlider").GetComponentInChildren<Slider> ();
		fatigueSlider = GameObject.Find ("FatigueSlider").GetComponentInChildren<Slider> ();
		InitSlider (fullSlider,startFull);
		InitSlider (fatigueSlider, startFatigue);
		anim = gameObject.GetComponent<Animator> ();
	}

	void Update () {
		asi = gameObject.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0); //取得動畫狀態
	}

	void FixedUpdate(){
		
		fatigueTime += Time.deltaTime;
		fullTime += Time.deltaTime;
		Full ();
		Fatigue ();
	}

	private void InitSlider(Slider slider, float startValue){
		slider.value = slider.maxValue = startValue;
	}
}
