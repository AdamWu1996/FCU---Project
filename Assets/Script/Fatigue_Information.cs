using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fatigue_Information : MonoBehaviour {

	public int startFatigue = 100;
	public Slider fatigueSlider;
	private GameObject cat;
	private static int currentFatigue;
	private float time = 0;
	private Animator anim;
	private AnimatorStateInfo asi;

	void Awake(){
		
		cat = GameObject.Find ("Cat Lite");
		anim = cat.GetComponent<Animator> ();

		fatigueSlider.maxValue = startFatigue; //初始化飽滿度最大值

		if (currentFatigue <= 0) { //死掉後重新開始
			fatigueSlider.value = startFatigue;
			currentFatigue = startFatigue;
		}
		else {
			fatigueSlider.value = startFatigue; //正常初始化
		}

	}

	public void GraduallyTired(){
		if (time > 3) {
			fatigueSlider.value -= 30;
			time = 0;
		}
	}

	public void GraduallyRest(){
		if (time > 3) {
			fatigueSlider.value += 30;
			time = 0;
		}
	}

	void FixedUpdate(){
		
		Debug.Log ("Fatigue : " + asi.IsName("Fatigue"));
		Debug.Log ("Idle : " + asi.IsName("Idle"));
		Debug.Log ("Run : " + asi.IsName("Run"));
		asi = anim.GetCurrentAnimatorStateInfo (0);
		time += Time.deltaTime;
		
		if (asi.IsName ("Idle")) { //每過三單位且疲勞值>0
			if (fatigueSlider.value <= 0)
				anim.SetTrigger ("isFatigue");
			else 
				GraduallyTired ();	
		}
		else if(asi.IsName("Fatigue")){
			if(fatigueSlider.value != 100)
				GraduallyRest ();
			else
				anim.SetTrigger("notFatigue");
		}

	}
}
