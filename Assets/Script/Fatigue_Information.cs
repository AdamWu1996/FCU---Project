using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fatigue_Information : MonoBehaviour {

	public int startFatigue = 100;
	public Slider fullSlider;
	private static int currentFatigue;
	private float time = 0;

	void Awake(){

		fullSlider.maxValue = startFatigue; //初始化飽滿度最大值

		if (currentFatigue <= 0) { //死掉後重新開始
			fullSlider.value = startFatigue;
			currentFatigue = startFatigue;
		}
		else {
			fullSlider.value = startFatigue; //正常初始化
		}

	}

	public void GraduallyTired(){
		fullSlider.value -= 20;
		time = 0;
	}

	void FixedUpdate(){

		time += Time.deltaTime;

		if(time > 3)
			GraduallyTired ();
	}

}
