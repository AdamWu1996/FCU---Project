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
		asi = anim.GetCurrentAnimatorStateInfo (0);

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
		fatigueSlider.value -= 50;
		time = 0;
	}

	public void GraduallyRest(){
		fatigueSlider.value += 30;
		time = 0;
	}

	void FixedUpdate(){
		
		Debug.Log ("Fatigue : " + asi.IsName("Fatigue"));
		Debug.Log ("Idle : " + asi.IsName("Idle"));
		Debug.Log ("Run : " + asi.IsName("Run"));

		time += Time.deltaTime;

		if (time > 3 && asi.IsName ("Idle") && fatigueSlider.value > 0 ) { //每過三單位且疲勞值>0
			GraduallyTired ();
		}			
		else if(fatigueSlider.value <= 0 && asi.IsName("Idle")){ //疲勞值低於0且在一般動畫
			anim.SetTrigger("isFatigue");
		}

		if (fatigueSlider.value <= 0 && asi.IsName ("Fatigue")) { //疲勞值低於0且在疲勞動畫
			fatigueSlider.value += 5;
		}

	}
}
